﻿using UnityEngine;
using System.Collections;

public class MouseChaseLAb : MonoBehaviour {
    public Transform cat;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 directionToCat = (cat.position-transform.position);
        

        //       declare a var of type Vector3, called "directionToCat", set to a vector that goes from[current position] to[cat's current position]
        // to determine angle between two directions, google "Vector3.Angle"
        //if he angle between[current forward direction] vs. [directionToCat] is less than 180 degrees, then...
        if (Vector3.Angle(transform.forward, directionToCat) < 180f)
        {
            Ray mouseRay = new Ray(transform.position, directionToCat);
            RaycastHit mouseRayHitInfo = new RaycastHit();
            if (Physics.Raycast(mouseRay, out mouseRayHitInfo, 100))
            {
                if(mouseRayHitInfo.collider.tag=="Cat")
                {
                    GetComponent<Rigidbody>().AddForce(-directionToCat.normalized * 1000f);
                    GetComponent<AudioSource>().Play();
                }
            }
        }
//   declare a var of type Ray, called "mouseRay" that starts from[current position] and goes along[directionToCat]
//    declare a var of type RaycastHit, called "mouseRayHitInfo"
//if raycast with mouseRay and mouseRayHitInfo for 100 units is TRUE, then...
//        if mouseRayHitInfo.collider.tag is exactly equal to the word "Cat"... (mouse sees cat!)
//            add force on rigidbody, along[-directionToCat.normalized * 1000f] (run away!)
	
	}
}
