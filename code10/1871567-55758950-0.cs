    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine.SceneManagement;
    using UnityEngine;
    
    public class LampScript : MonoBehaviour
    {
    
        private bulbmanager bulbreq;
        public GameObject wincheck;
        //private bulbsmustcollect bulblvl;
        // Start is called before the first frame update
        void Start()
        {
            bulbreq = FindObjectOfType<bulbmanager>();
    
            //bulblvl = FindObjectOfType<bulbsmustcollect>();
        }
    
        // Update is called once per frame
        void Update()
        {
            if (bulbreq.bulbcount >= 8)
            {
                wincheck.gameObject.SetActive(true);            
    
            }
        }
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                if (bulbreq.bulbcount >= 8)
                {
                    //loop.Stop();
                    SceneManager.LoadScene("Level 2");
                }
          
            }
        }
    }
