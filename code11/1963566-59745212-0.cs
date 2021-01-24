    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Main : MonoBehaviour
    {
        bool isD;
        public GameObject Side;
        void Start()
        {
        }
    
        // Update is called once per frame
        void Update()
        {
           isD = Something.GetComponent<Something>().isDead;
           Debug.Log(isD);
        }
    } 
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
        public class Side : MonoBehaviour
        {
            public bool isDead;
            void Awake() // called prior to any Start
            {
                isDead = false;
            }
        
            // Empty magic methods waste cycles
        }
