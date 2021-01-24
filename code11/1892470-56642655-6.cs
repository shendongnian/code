    // set move speed in Units/seconds in the Inspector
    public float moveSpeed = 1f;
    private Vector3 desiredPos;
    private bool isMoving;
    private void Update()
    {
        if (!isMoving && Input.GetMouseButtonDown(0))
        {
            desiredPos = transform.position + Vector3.right * 1.5f;
            isMoving = true;
        }
    
        if (!isMoving && Input.GetMouseButtonDown(1))
        {
            desiredPos = transform.position - Vector3.right * 1.5f;
            isMoving = true;
        }
        
        if(isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, desiredPos, moveSpeed * Time.deltaTime);
    
            // this == is true if the difference between both
            // vectors is smaller than 0.00001
            if(transform.position == desiredPos)
            {
                isMoving = false;
                // So in order to eliminate any remaining difference
                // make sure to set it to the correct target position
                transform.position = desiredPos;
            }
        }
    }
    
