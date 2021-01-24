    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    public class slimecontroller : MonoBehaviour
    {
        private float movespeed = 0.1f;
        public slimespawner slisp;
    
        void Start()
        {
            slisp = GameObject.Find("Canvas").GetComponent<slimespawner>();
        }
        void Update()
        {
            slisp.points += 1;
        }
    }
