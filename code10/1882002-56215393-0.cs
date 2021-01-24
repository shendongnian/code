    moveD = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    moveD = transform.TransformDirection(moveD.normalized) * speed;
    moveDA = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
    if (moveDA.magnitude > 0) 
    { 
      gameObject.transform.GetChild(0).LookAt(gameObject.transform.position + moveDA, Vector3.up);
    }
    if (controller.isGrounded)
    {
      if (Input.GetButton("Jump"))
      {
        moveD.y = jumpSpeed;
      }
    }
    moveD.y = moveD.y - (gravity * Time.deltaTime);
    controller.Move(moveD * Time.deltaTime);
