    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class Stack_rotate : MonoBehaviour
    {
        float rotationAngleOverZAxisPerFrame = 20f;
    
        void Update()
        {
            transform.Rotate(new Vector3(0, 0, rotationAngleOverZAxisPerFrame), Space.Self);
        }
    }
