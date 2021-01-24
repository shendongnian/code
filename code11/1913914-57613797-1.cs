    public class ArrowController : MonoBehaviour
    {
        public Rigidbody2D rb;
        public float speed = 5.0f;
        public Vector2 pos;
    
        // store and re-use references!
        // would be better to already reference them via drag&drop
        // in the Inspector
        [SerializeField] private GameObject gunArm;
        [SerializeField] private Camera cam;
        private void Start()
        {
            rb = GetComponent<Rigidbody2D>();
        }
        private void Update()
        {
            testForClick();
        }
    
        private void FixedUpdate()
        {
            // also do this here
            faceMouse();
            if (doForce)
            {
                doForce = false;
                rb.AddForce(transform.forward);
            }
        }
    
        private bool doForce;
    
       
    
        private void faceMouse()
        {
            // try to reuse the reference
            if(!cam) cam = Camera.main;
            var mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    
            // try to re-use the reference
            if (!gunArm) gunArm = GameObject.Find("gunArm");
    
            var difference = gunArm.transform.position - mousePos;
            var gunAngle = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            gunArm.rotation = Quaternion.Euler(0, 0, gunAngle);
        }
    
        private void testForClick()
        {
            if (Input.GetMouseButtonDown(0))
            {
                print("click");
                // only set the flag
                doForce = true;
            }
        }
    }
