    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("Walk", true);
            if (Input.GetKey(KeyCode.LeftShift))
            {
                anim.SetBool("Sprint", true);
                anim.SetBool("Idle", true);
            }
        }
        /////////////////////////////////////////
        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", false);
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            anim.SetBool("Sprint", false);
        }
    }
