    void Update()
    {
       if (Input.GetMouseButton(0))
       {
          anim.SetBool("open", !(anim.GetBool("open")));
       }
    }
