    void Update()
    {
        //Get Button will fire this continuously as you keep it pressed. 
        //Consider using GetButtonDown, or implement delayed repetition.
        if (Input.GetButton("Fire1"))
        {
            FindObjectOfType<AudioManager>().Play("Spraycan");
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            FindObjectOfType<AudioManager>().Stop("Spraycan");
        }
    }
