    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class CreateDestroyAR : MonoBehaviour {
    
        //PAGE HAS BEEN CREATED AS A PREFAB
        public GameObject Page;
        private GameObject instantiatedPage;
        public void CreatePage() {
           instantiatedPage = Instantiate(Page);
        }
    
        public void DestroyPage()
        {
            Destroy(instantiatedPage);
        }
    }
