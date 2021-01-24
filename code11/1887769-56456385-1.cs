    [RequireComponent(typeof(Camera))]
    public class DisableSubCamShadows : MonoBehaviour
    {
        // either drag this in via the inspector
        public Camera mainCamera;
    
        private ShadowQuality _originalShadowSettings
    
        // or get it on runtime
        private void Awake()
        {
            // mainCamera will be the one attached to this object
            mainCamera = GetComponent<Camera>();
    
            // store original shadow settings
            _originalShadowSettings = QualitySettings.shadows;
        }
    
        private void OnEnable()
        {
            // register the callbacks when enabling object
            Camera.onPreRender += MyPreRender;
            Camera.onPostRender += MyPostRender;
        }
    
        private void OnDisable()
        {
            // remove the callbacks when disabling object
            Camera.onPreRender -= MyPreRender;
            Camera.onPostRender -= MyPostRender;
        }
    
        // callback before ANY camera starts rendering
        private void MyPreRender(Camera cam)
        {
            // if mainCamera set to originalShadowSettings 
            // could also simply return but just to be sure
            //
            // for other camera disable shadows
            QualitySettings.shadows = cam == mainCamera ? originalShadowSettings : ShadowQuality.Disable;   
        }
    
        // callback after ANY camera finishes rendering
        private void MyPostRenderer(Camera cam)
        {
            // restore shadow settings
            QualitySettings.shadows = originalShadowSettings;
        }
    }
