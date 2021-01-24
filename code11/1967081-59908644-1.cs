    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
        
    public class Stack_rotate : MonoBehaviour
    {
         float rotationAngleOverZAxisPerFrame = 1200f;
    
         void Update()
         {
             transform.Rotate(new Vector3(0, 0, rotationAngleOverZAxisPerFrame * Time.deltaTime), Space.Self);
         }
    }
