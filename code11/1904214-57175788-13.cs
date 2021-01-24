    public class CameraScript : MonoBehaviour
    {
        public float MovementAmplitude = 0.1f;
        public float MovementFrequency = 2.25f;
    
        // reference the player object here
        public Transform playerTransform;
    
        private float originalLocalPosY;
    
        private void Start()
        {
            if(!playerTransform) playerTransform = transform.parent;
            originalLocalPosY = transform.localPosition.y;
        }
    
        private void LateUpdate()
        {
            transform.localPosition = Vector3.up * (originalLocalPosY + Mathf.Cos(playerTransform.position.z * MovementFrequency) * MovementAmplitude);
        }
    }
