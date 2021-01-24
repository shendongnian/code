    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    
    public class collision : MonoBehaviour
    {
        public GameObject sword;
        public float slashtime;
    
    
    
        private void OnTriggerEnter(Collider collider)
        {
            sword = collider.gameObject;
            slashtime=sword.GetComponent<movement>().slashtime;
            if (collider.tag == "sword" && slashtime+1f > Time.time)
            {
                Destroy(gameObject);
            }
        }
    }
