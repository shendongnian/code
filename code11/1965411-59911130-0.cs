    private Touch touch;
    private Vector2 oldTouchPosition;
    private Vector2 NewTouchPosition; 
    [SerializeField]
    private float keepRotateSpeed = 10f;
    private void Update()
    {
         RotateThings(); 
    }
    private void RotateThings()
    {
      if (Input.touchCount > 0)
        {
            touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                oldTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                NewTouchPosition = touch.position;
            }
            Vector2 rotDirection = oldTouchPosition - NewTouchPosition;
            Debug.Log(rotDirection);
            if (rotDirection.x < 0 )
            {
                RotateRight();
            }
            else if (rotDirection.x > 0 )
            {
                RotateLeft();
            }
        }
    }
    void RotateLeft()
        {
            transform.rotation = Quaternion.Euler(0f, 1.5f * keepRotateSpeed, 0f) * transform.rotation;
        }
    void RotateRight()
    {
        transform.rotation = Quaternion.Euler(0f, -1.5f * keepRotateSpeed, 0f) * transform.rotation;
    }
    
