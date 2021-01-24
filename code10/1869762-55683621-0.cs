    [RequireComponent(typeof(Camera))]
    public class MainCameraProvider : MonoBehaviour
    {
        public static Camera MainCamera;
    
        private void Awake()
        {
            // check if already set by another instance
            if(MainCamera)
            {
                Debug.LogWarning("MainCamera is already set!");
                Destroy(gameObject);
            }
    
            MainCamera = GetComponent<Camera>();
        }
    }
