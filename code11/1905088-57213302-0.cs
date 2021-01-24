        if (Input.GetKey(KeyCode.W))
    {
        anim.SetBool("Walk", true);
        anim.SetBool("Sprint", false);
    }
    if (Input.GetKey(KeyCode.LeftShift))
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetBool("Sprint", true);
            anim.SetBool("Walk", false);
        }
    }
