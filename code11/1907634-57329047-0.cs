    public float speed = 5f;
    public float sensitivity = 2f;
    public GameObject Camera;
    CharacterController controller;
    float moveFB;
    float moveLR;
    public float rotX;
    public float rotY;
    public float minAngle = -90f;
    public float maxAngle = 90f;
    
    
    void Start()
    {
        controller = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
    }
    // Update is called once per frame
    void FixedUpdate ()
    {
        moveFB = Input.GetAxis("Vertical");
        moveLR = Input.GetAxis("Horizontal");
        rotX = Input.GetAxis("Mouse X") * sensitivity;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity;
        rotY = Mathf.Clamp(rotY, minAngle, maxAngle);
        transform.Rotate(0, rotX, 0);
        Vector3 movement = new Vector3(moveLR * speed * Time.deltaTime, 0, moveFB * speed * Time.deltaTime);
        controller.Move(transform.rotation * movement);
        Camera.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
       
    }
}
