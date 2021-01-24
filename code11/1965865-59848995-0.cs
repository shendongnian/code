    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class collision : MonoBehaviour
    {
        private GameObject _sword;
        private float _slashTime;
        private void Start()
        {
            _slashTime = GameObject.Find("Movement").GetComponent<Movement>().GetSlashTime();
        }    
      
        private void OnTriggerEnter(Collider collider)
        {           
            if (collider.CompareTag("sword") && _slashTime + 1f > Time.time)
            {
                Destroy(gameObject); // What is gameObject in this context?  the _sword?  something else?
            }
        }
    }
