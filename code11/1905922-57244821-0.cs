    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class SkyBox : MonoBehaviour
    {
        public Material[] skyboxes;
    
        private int index = 0;
    
        // Start is called before the first frame update
        void Start()
        {
    
        }
    
        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                index++;
                if (index == skyboxes.Length)
                    index = 0;
                RenderSettings.skybox = skyboxes[index];
            }
        }
    }
