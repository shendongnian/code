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
     
            Vector3 rotateVector = Vector3.zero;
    
            if(Input.GetKey("up")){
                doRotate = true;
                rotateVector += transform.right;
            }
            else if(Input.GetKey("down")){
                doRotate = true;
                rotateVector -= transform.right;
            }
    
            if(Input.GetKey("right")){
                doRotate = true;
                rotateVector -= transform.up;
            }
            
            if(Input.GetKey("left")){
                doRotate = true;
                rotateVector += transform.up;
            }
    
            if (rotateVector.sqrMagnitude > 0) // if rotateVector is nonzero
            {
                mainCam.transform.RotateAround(refpoint.transform.position, rotateVector, 50 * Time.deltaTime);
            }
           
    
            phobos.transform.RotateAround(mars.transform.position, phobos.transform.up, 60*Time.deltaTime);
            deimos.transform.RotateAround(mars.transform.position, deimos.transform.up, 50*Time.deltaTime);
    
        }
    }
