    public class GameManagerScript : MonoBehaviour
    {
        // Start is called before the first frame update
        public GameObject mars;//planet
        public GameObject phobos;//moon1
        public GameObject deimos;//moon2
        public GameObject refpoint;//empty game object I placed inside mars
        //All object are referenced using the inspector
    
        public float cameraAngularVelocity = 60f;
        public float cameraDistance = 200;
        public float cameraAngleY = 0;
        public float cameraAngleX = 0;
    
        private Camera mainCam;
    
        void Start()
        {
            mainCam = Camera.main;
        }
    
        void Update()
        {
            float angleDelta = cameraAngularVelocity * Time.deltaTime;
    
            //Standard Input management
            if (Input.GetKey("up"))
            {
                cameraAngleX += angleDelta;
            }
            if (Input.GetKey("down"))
            {
                cameraAngleX -= angleDelta;
            }
            if (Input.GetKey("right"))
            {
                cameraAngleY -= angleDelta;
            }
            if (Input.GetKey("left"))
            {
                cameraAngleY += angleDelta;
            }
            //Alternative using axis
            cameraAngleX += Input.GetAxis("Vertical") * angleDelta;
            cameraAngleY += Input.GetAxis("Horizontal") * angleDelta;
    
            //Protections
            cameraAngleX = Mathf.Clamp(cameraAngleX, -90f, 90f);
            cameraAngleY = Mathf.Repeat(cameraAngleY, 360f);
    
            Quaternion cameraRotation =
                Quaternion.AngleAxis(cameraAngleY, Vector3.up)
                * Quaternion.AngleAxis(cameraAngleX, Vector3.right);
    
            Vector3 cameraPosition =
                refpoint.transform.position
                + cameraRotation * Vector3.back * cameraDistance;
    
            mainCam.transform.position = cameraPosition;
            mainCam.transform.rotation = cameraRotation;
    
            phobos.transform.RotateAround(mars.transform.position, phobos.transform.up, 60 * Time.deltaTime);
            deimos.transform.RotateAround(mars.transform.position, deimos.transform.up, 50 * Time.deltaTime);
        }
    }
