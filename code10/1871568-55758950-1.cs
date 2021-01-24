    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class checkifdone : MonoBehaviour
    {
    
        public AudioSource checkwin;
        public GameObject wincheck;
        // Start is called before the first frame update
        void Start()
        {
            wincheck.gameObject.SetActive(false); //This is the same object where script is.
    
    
        }
    
        private void OnEnable()
        {
            checkwin.Play();
    
        }
    }
