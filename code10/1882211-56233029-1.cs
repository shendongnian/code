    void FixedUpdate()
    {
    
        Debug.Log(jumpCount);
        if(transform.position.y < -14) { SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); }
    
    
        foreach (Touch FingerTouch in Input.touches)
        {
            if (FingerTouch.position.x < Screen.width / 2)
            {
                if (FingerTouch.phase == TouchPhase.Began)
                {
                    FingerInitialPosition = FingerTouch.position.x;
                }
                else if (FingerTouch.phase == TouchPhase.Moved)
                {
                    FingerMovedPosition = FingerTouch.position.x;
    
                    if (FingerMovedPosition > FingerInitialPosition)
                    {
                         float hval = rb.velocity.x;
                         hval += 19f;
                         hval *= Mathf.Pow(0.5f, Time.deltaTime * 10f);
                         rb.velocity = new Vector2(hval, rb.velocity.y);
    
    
    
                    }
                    else if (FingerMovedPosition < FingerInitialPosition)
                    {
                        float hval = rb.velocity.x;
                        hval -= 19f;
                        hval *= Mathf.Pow(0.5f, Time.deltaTime * 10f);
                        rb.velocity = new Vector2(hval, rb.velocity.y);
                    }
                }
                else if (FingerTouch.phase == TouchPhase.Ended)
                {
                    FingerInitialPosition = 0f;
                    FingerMovedPosition = 0f;
    
                }
                else //NEW PART!//
                {
                    FingerMovedPosition = FingerTouch.position.x;
                    if (FingerMovedPosition > FingerInitialPosition)
                    {
                        float hval = rb.velocity.x;
                        hval += 19f;
                        hval *= Mathf.Pow(0.5f, Time.deltaTime * 10f);
                        rb.velocity = new Vector2(hval, rb.velocity.y);
                    }
                    else if (FingerMovedPosition < FingerInitialPosition)
                    {
                        float hval = rb.velocity.x;
                        hval -= 19f;
                        hval *= Mathf.Pow(0.5f, Time.deltaTime * 10f);
                        rb.velocity = new Vector2(hval, rb.velocity.y);
    
                    }
                }
            }
    
            else if (FingerTouch.position.x > Screen.width / 2)
            {
                if (FingerTouch.deltaPosition.y > 0) {
                    if (jumpCount<1) {
                        rb.AddForce(jump * jumpForce, ForceMode2D.Impulse);
                        jumpCount += 1;
                    }
                }
            }
    
        }
    }
