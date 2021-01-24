    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class RotateCamera : MonoBehaviour
    {
        public GameObject objectToSpin;
        public Vector3 spinAxis;
        public float timeToSpin = 5f;
        public float spinSpeed = 20f;
        public bool randomSpin = false;
    
        private void Start()
        {
            var rb = GetComponent<Rigidbody>();
            rb.angularVelocity = Random.insideUnitSphere;
            StartCoroutine("Spin");
        }
    
        private void Update()
        {
        }
    }
    IEnumerator Spin() 
    {
        float spinTimer;
        while (true)
        {
            if (randomSpin == true)
            { 
                spinAxis = Random.onUnitSphere;
            }
 
            spinTimer = timeToSpin;
            while (spinTimer > 0f) 
            {
                objectToSpin.transform.Rotate(spinAxis, Time.deltaTime * spinSpeed);
                spinTimer -= Time.deltaTime;
                yield return null;
            }
        }
    }
