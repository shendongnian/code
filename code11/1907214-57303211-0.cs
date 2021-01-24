    private bool isMoving;
    private void Update()
    {
        // ignore user input until current movement has finished
        if(isMoving) return;
        // avoid repeated API calls
        var input = Input.GetAxis("Horizontal");
        if (input < 0)
        {
            isMoving = true;
            //This is to flip image
            transform.eulerAngles = new Vector3(0, 180, 0);
            //starts animation
            animator.SetBool("isSkipping", true);
            //starts the movement function with the direction to move in
            StartCoroutine(Movement(input));
        }
        else if (input > 0)
        {
            isMoving = true;
            //This is to flip image
            transform.eulerAngles = new Vector3(0, 0, 0);
            //starts animation
            animator.SetBool("isSkipping", true);
            //starts the movement function with the direction to move in
            StartCoroutine(Movement(input));
        }
    }
    
