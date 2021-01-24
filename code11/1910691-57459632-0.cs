    public float jumpCoolDownTime;
    private float coolDownTimer;
    private bool canJump;
    void Update()
    {
        // if no can jump you can't jump again
        if(!canJump)
        {
            verticalAxis = Input.GetAxisRaw("Vertical");
            if (verticalAxis > 0)
            {
                canJump = false;
                isJumping = true;
                coolDownTimer = 0;
            }
        }
        else
        {
            // run timer to enable jump again
            if(isGrounded) coolDownTimer += Time.deltaTime;
 
            if(coolDownTimer >= jumpCoolDownTime)
            {
                canJump = true;
            }
        }
    }
