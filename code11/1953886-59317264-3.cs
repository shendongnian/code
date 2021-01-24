    using UnityEngine;
    using GoogleARCore;
    namespace CompanyController
    {
        public class UIController : MonoBehaviour
        {
            // Reference this via the Inspector by drag and drop 
            // [SerializeField] simply allows to serialize also private fields in Unity
            [SerializeField] private ARCoreBackgroundRenderer arRenderer;
            // Alternatively you could as said use the type like
            //[SerializeField] private GoogleARCore.ARCoreBackgroundRenderer arRenderer;
            private void Awake ()
            {
                // As a fallback find it on the scene
                if(!arRenderer) arRenderer = FindObjectOfType<ARCoreBackgroundRenderer>();
            }
            public void DisableARBackgroundRendering()
            {
                // Now use any public method of the arRenderer 
                arRenderer.SomePublicMethod();
            }
        }
    }
