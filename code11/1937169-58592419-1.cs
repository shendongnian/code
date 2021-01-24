    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.EventSystems;
    public class MyScript: MonoBehaviour {
    
        public EventSystem eventSystem;
        public GameObject selectedObject;
    
        private bool buttonSelected = false;
    
        void Start () {
            eventSystem.SetSelectedGameObject (selectedObject);
        }
    
        void Update() {
           //To get which element is selected.
            print (eventSystem.currentSelectedGameObject.name);
        }
    
        private void OnDisable () {
            buttonSelected = false;
        }
    
    }
