    float timer = 0f;
    void Update()
    {
        var dir = Input.GetAxis("Horizontal");
        if (0 > dir)
        {
            //This is to flip image
            transform.eulerAngles = new Vector3(0, 180, 0);
            //starts animation
            animator.SetBool("isSkipping", true);
            //calls the movement function with the direction to move in
            timer +=Time.deltaTime;
            if(timer >= 0.5){
               ExecuteMovement(dir);
               timer -=0.5f;
            }
            //Movement(Input.GetAxis("Horizontal"));
        }
        else if (0 < dir)
        {
            //This is to flip image
            transform.eulerAngles = new Vector3(0, 0, 0);
            //starts animation
            animator.SetBool("isSkipping", true);
            //calls the movement function with the direction to move in
            timer +=Time.deltaTime;
            if(timer >= 0.5){
               ExecuteMovement(dir);
               timer -=0.5f;
            }
            //Movement(Input.GetAxis("Horizontal"));
        }
    }
