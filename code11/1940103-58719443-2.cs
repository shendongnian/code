    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class TransformReset : MonoBehaviour
    {
        private Transform LocalTransform;
        private Vector3 InitialPos;
        private Quaternion InitialRot;
    
        private Vector3 CurrentPos;
        private Quaternion CurrentRot;
    
        void Start()
        {
            InitialPos = transform.position;
            InitialRot = transform.rotation;       
        }
    
        public void ResetTransform()
        {
            transform.position = InitialPos;
            transform.rotation = InitialRot;
            Debug.Log("resetting position of " + gameObject.name);
        }
    }
