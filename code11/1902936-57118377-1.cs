    [SerializeField] private string horizontalInputName;
    [SerializeField] private string verticalInputName;
    [SerializeField] private float movementSpeed;
    private CharacterController charController;
    [SerializeField] private AnimationCurve jumpFallOff;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private KeyCode jumpKey;
    private bool isJumping = false;
    private float timeInAir = 0.0f;
    private void Awake()
    {
        charController = GetComponent<CharacterController>();
    }
    private void Update()
    {
        PlayerMovement();
    }
    private void PlayerMovement()
    {
        float forwardInput = Input.GetAxis(verticalInputName);
        float rightInput = Input.GetAxis(horizontalInputName);
        Vector3 forwardMovement = transform.forward * forwardInput;
        Vector3 rightMovement = transform.right * rightInput;
        Vector3 horizMovement = (forwardMovement+rightMovement) * movementSpeed;
        float jumpVelocity = JumpInput();
        if (isJumping)
        {
            Vector3 vertMovement = Vector3.up * jumpVelocity * jumpMultiplier;
            charController.Move((horizMovement + vertMovement) * Time.deltaTime) 
        } 
        else
        {
            charController.SimpleMove(horizMovement);
        }
    }
    private float JumpInput()
    {
        float jumpVelocity = 0f;
        if (Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            charController.slopeLimit = 90.0f;
            timeInAir = 0f;
        }
        
        if (isJumping){
            if (timeInAir == 0f || 
                   (!charController.isGrounded 
                    && charController.collisionFlags != CollisionFlags.Above))
            {
                jumpVelocity = jumpFallOff.Evaluate(timeInAir);
                timeInAir += Time.deltaTime;
            } 
            else
            {
                ifJumping = false;
            }
        }
        return jumpVelocity;
    }
