    using UnityEngine;
    using GoogleARCore;
    namespace Company controller
    {
        public class UIController : MonoBehaviour
        {
            // Reference this via the Inspector by drag and drop 
            [SerializeField] private ARCoreBackgroundRenderer arRenderer;
            private void Awake ()
            {
                // As a fallback find it on the scene
                if(!arRenderer) arRenderer = FindObjectOfType<ARCoreBackgroundRenderer>();
            }
            public void Example()
            {
                // Now use any public method of the arRenderer 
                arRenderer.SomePublicMethod();
            }
        }
    }
