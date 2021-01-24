bool facingRight;
    int jumpPhase = 1;
    float timer = 0f;
    float dir;
    void Update()
    {
        if (jumpPhase != 3)
        {
            dir = Input.GetAxis("Horizontal");
        }
        
        if (0 > dir || (jumpPhase == 3 && facingRight == true))
        {
            timer += Time.deltaTime;
            
            if (facingRight != true)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
                jumpPhase = 1;
                timer = 0f;
                facingRight = true;
            }
            else if (jumpPhase == 1)
            {
                //starts animation
                animator.SetBool("isSkipping", true);
                if (timer >= 0.415f)
                {
                    jumpPhase = 2;
                }
            }
            else if (jumpPhase == 2)
            {
                ExecuteMovement(dir);
                if (timer >= 0.995f)
                {
                    jumpPhase = 3;
                }
            }
            if (jumpPhase == 3)
            {
                if (timer >= 1.5f)
                {
                    jumpPhase = 1;
                    timer = 0f;
                }
            }
        }
        else if (0 < dir || (jumpPhase == 3 && facingRight != true))
        {
            timer += Time.deltaTime;            
            if (facingRight == true)
            {                
                transform.eulerAngles = new Vector3(0, 0, 0);
                jumpPhase = 1;
                timer = 0f;
                facingRight = false;
            }
            else if (jumpPhase == 1)
            {
                //starts animation
                animator.SetBool("isSkipping", true);
                if (timer >= 0.415f)
                {
                    jumpPhase = 2;
                }
            }
            else if (jumpPhase == 2)
            {
                ExecuteMovement(dir);
                if (timer >= 0.995f)
                {
                    jumpPhase = 3;
                }
            }
            if (jumpPhase == 3)
            {
                if (timer >= 1.5f)
                {
                    jumpPhase = 1;
                    timer = 0f;
                }
            }
        }
    }
