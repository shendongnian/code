    public class PlayerCameraController : MonoBehaviour
    {
        public float sensitivity = 5.0f;
        public float smoothing = 2.0f;
    
        private UnityEngine.GameObject player;
        private Vector2 smoothV;
    
        // Use this for initialization
        void Start()
        {
            player = this.transform.parent.gameObject;
        }
    
        // Update is called once per frame
        void Update()
        {
            if (PauseManager.gamePaused == false)
            {
                var md = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
    
                md = sensitivity * smoothing * md;
                smoothV.x = Mathf.Lerp(smoothV.x, md.x, 1f / smoothing);
                smoothV.y = Mathf.Lerp(smoothV.y, md.y, 1f / smoothing);
    
                Vector3 modifiedEulers = transform.localEulerAngles + Vector3.right * smoothV;    
                modifiedEulers.x = Mathf.Clamp(modifiedEulers.x, -90f, 90f);
    
                transform.localEulerAngles = modifiedEulers;
                player.transform.Rotate(0f, smoothV.x, 0f);
            }
        }
    }
