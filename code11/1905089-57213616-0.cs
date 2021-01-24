    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk", true);
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                anim.SetBool("Sprint", true);
                anim.SetBool("Walk", false);
            }
        }
        /////////////////////////////////////////
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Sprint", false);
            anim.SetBool("IdleToSprint", false);
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                anim.SetBool("SprintToWalk", true);
            }
        }
    }
