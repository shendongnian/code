    public class you : MonoBehaviour
    {
        public const float InitialSpeed = 20f; 
        public float upForce = 100f;
        public LayerMask ground;
        private Rigidbody2D rb2d;
        public float speed = InitialSpeed; // Here 
        public bool isgrounded = true;
        public float checkradius = 0.5f;
        public GameObject groundcheck;
        public float translation = Input.GetAxis("Horizontal") * InitialSpeed; // And Here
    // Rest of the code
