using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph : MonoBehaviour {
    public Transform pointPrefab;
    //initialize an array of transforms
    Transform[] points;
  
    [Range(10,100)] public int resolution = 10;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		for (int i=0; i < points.Length; i++)
        {
            //Get the current point and its position
            Transform point = points[i];
            Vector3 position = point.localPosition;

            //Derive the y position from the above values
            //position.y = (position.x * position.x * position.x);

            position.y = Mathf.Sin(Mathf.PI * (position.x + Time.time));
            //Apply the newly changed variable value to our point
            point.localPosition = position;
        }
	}

    void Awake()
    {
        //create the object associated with points, using the new keyword. the size is resolution
        points = new Transform[resolution];
        float step = 2f / resolution;
        Vector3 scale = Vector3.one * step;
        Vector3 position;

        position.z = 0;
        //We are now updating the y value in Update, so we must set it to 0 upon wake.
        position.y = 0;

        
            for (int i=0; i < points.Length; i++)
            {
            Transform point = Instantiate(pointPrefab);

            position.x = (i + 0.5f) * step - 1f;
            //y is equal to x, this represents f(x) = x.
            //position.y = position.x;

            //f(x) = x^2:
            //position.y = (position.x * position.x);

            //f(x) = x^3
           // position.y = (position.x * position.x * position.x);
            point.localPosition = position; 
            // use the scale variable to reduce CPU as the size stays the same
            point.localScale = scale;
            point.SetParent(transform,false);
            points[i] = point;

            }

        
    }
}
