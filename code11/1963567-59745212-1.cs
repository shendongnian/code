    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Main : MonoBehaviour
    {
        bool isD;
        public Something something;
        void Start()
        {
         something = GetComponent<Something>();
        }
    
        // Update is called once per frame
        void Update()
        {
           isD = something.isdead;
           Debug.Log(isD);
        }
    } 
   
