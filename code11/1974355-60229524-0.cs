    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class MouseLook : MonoBehaviour
    {
        public float mouseSensitivity = 100f;
        public float minAngle = -45f;
        public float maxAngle = 45f;
        public float minPosition = 0f;
        public float maxPosition = 6f;
        public float camDefaultY = 3.198001f;
        public GameObject cameraTarget;
        public GameObject headTarget;
    
        private float yaw = 0f;
        private float pitch = 0f;
    
        private Transform targetAngle;
        // Start is called before the first frame update
        void Start()
        {
            targetAngle = cameraTarget.transform;
        }
    
        // Update is called once per frame
        void Update()
        {
            yaw += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
            pitch -= Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
            pitch = Mathf.Clamp(pitch, minAngle, maxAngle);
    
            transform.eulerAngles = new Vector3(0f, yaw, 0f);
            cameraTarget.transform.eulerAngles = new Vector3(-pitch, targetAngle.eulerAngles.y, targetAngle.eulerAngles.z);
        }
    
        void LateUpdate()
        {
            headTarget.transform.eulerAngles = new Vector3(-pitch, targetAngle.eulerAngles.y, targetAngle.eulerAngles.z);
        }
    }
    
