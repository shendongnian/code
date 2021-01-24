    using UnityEngine;
    
    public class CameraTracking : MonoBehaviour
    {
    #pragma warning disable 0649
        [SerializeField] private GameObject _cube;
    #pragma warning restore 0649
    
        private Vector3 offset;
    
        void Awake()
        {
            offset = _cube.transform.position + transform.position;
        }
    
        void LateUpdate() {
            transform.position = _cube.transform.position + offset;
        }
    }
