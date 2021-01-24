    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Zoom : MonoBehaviour
    {
        public Camera cam;
        public float zoom_speed = 20f;
    
        // Update is called once per frame
        void Update ()
        {
             float d = Input.GetAxis("Mouse ScrollWheel");
             if (d > 0f)
             {
                //Positive value
                //Scroll up
                cam.fieldOfView += zoom_speed;
             }
             else if (d < 0f)
             {
                //Negative value
                //Scroll down
                cam.fieldOfView -= zoom_speed;
             }
        }
    }
