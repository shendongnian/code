    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MouseOrbit : MonoBehaviour
    {
        public float speedH = 2.0f;
        public float speedV = 2.0f;
    
        private float yaw = 180.0f;
        private float pitch = 0.0f;
    
        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    
        void Update()
        {
            yaw -= speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
    
            transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
        }
    }
