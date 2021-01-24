    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    namespace TestProgram
    {
        public class Floor_Control : MonoBehaviour
        {
            public float speed;
            public float max;
    
    		void FixedUpdate()
    		{
    			//Player Input
    			float step = speed * Time.deltaTime;
    			float tiltX = -Input.GetAxis("Horizontal") +         Input.GetAxis("Vertical");
    			float tiltZ = Input.GetAxis("Horizontal") +     Input.GetAxis("Vertical");
    			GetComponent<Rigidbody>().rotation =     Quaternion.RotateTowards(transform.rotation,     Quaternion.Euler(max * tiltZ, 0, max * tiltX), step);
    		}
    	}
    }
