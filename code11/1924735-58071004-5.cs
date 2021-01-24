    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class GameManagerScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject mars;//planet
        public GameObject phobos;//moon1
        public GameObject deimos;//moon2
        public GameObject refpoint;//empty game object I placed inside mars
        //All object are referenced using the inspector
    
        private Camera mainCam;
        private float cameraRotateSpeed = 50f;
        private float cameraMinVerticalAngle = 10f;
    
        void Start()
        {
            mainCam = Camera.main;
    
            mainCam.transform.position = new Vector3(0,0,-200);
    
            mainCam.transform.LookAt(mars.transform.position);
    
            Rigidbody rb = mars.GetComponent<Rigidbody>();
            rb.angularVelocity = new Vector3(0,20,0);
        }
    
        // Update is called once per frame
        void Update()
        {
     
            float horizontalRotateDirection = 0f;
            float verticalRotateDirection = 0f;
 
    
            if(Input.GetKey("up")){
                doRotate = true;
                verticalRotateDirection += 1f;
            }
            if(Input.GetKey("down")){
                doRotate = true;
                verticalRotateDirection -= 1f;
            }
    
            if(Input.GetKey("right")){
                doRotate = true;
                horizontalRotateDirection += 1f;
            }
            
            if(Input.GetKey("left")){
                doRotate = true;
                verticalRotateDirection -= 1f;
            }
            float horizontalRotateAmount = horizontalRotateDirection 
                    * cameraRotateSpeed * Time.deltaTime;
            float verticalRotateAmount = verticalRotateDirection 
                    * cameraRotateSpeed * Time.deltaTime;
            // Prevent camera from flipping
            Vector3 fromRefToCam = (mainCam.transform.position - refpoint.transform.position).normalized;
    
            float maxRotateDown = Vector3.Angle(Vector3.down, fromRefToCam);
            float maxRotateUp = Vector3.Angle(Vector3.up, fromRefToCam)
            verticalRotateAmount = Mathf.Clamp(verticalRotateAmount, 
                    cameraMinVerticalAngle - maxRotateDown, 
                    maxRotateUp - cameraMinVerticalAngle);
           
            Vector3 verticalRotateAxis = Vector3.Cross(Vector3.down, fromRefToCam); 
            //Rotate horizontally around global down
            mainCam.transform.RotateAround(refpoint.transform.position, 
                        Vector3.up, 
                        horizontalRotateAmount);
            // Rotate vertically around camera's right (in global space)
            mainCam.transform.RotateAround(refpoint.transform.position,
                        verticalRotateAxis, 
                        verticalRotateAmount);
           
    
            phobos.transform.RotateAround(mars.transform.position, phobos.transform.up, 
                    60*Time.deltaTime);
            deimos.transform.RotateAround(mars.transform.position, deimos.transform.up, 
                    50*Time.deltaTime);
    
        }
    }
