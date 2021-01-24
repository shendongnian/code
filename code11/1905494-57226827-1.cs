    ...
    void Animation()
    {
        if (Input.GetButtonDown("Fire1") && GetComponentInParent<PlayerController>().moving == false)
        {
            anim.SetBool("IsShooting", true);
        }
    
    
        if (Input.GetButtonUp("Fire1"))
        {
            anim.SetBool("IsShooting", false);
        }
    }
