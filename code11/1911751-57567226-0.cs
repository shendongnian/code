 bool hasJumped = false;
    // Update is called once per frame
 void Update()
 {
     if (controller.isGrounded)
     {
         if (Input.GetKey(KeyCode.W))
         {
            anim.SetBool("running", true);
            moveDirection = new Vector3(0, 0, 1);
            moveDirection *= speed;
         }
         if (Input.GetKeyUp(KeyCode.W))
         {
            anim.SetBool("running", false);
            moveDirection = new Vector3(0, 0, 0);
         }
         if (Input.GetKeyDown(KeyCode.Space))
         {
            anim.SetBool("jump", true);
            hasJumped = true;
            moveDirection.y = jumpSpeed;
         }
         else
         {
            anim.SetBool("jump", false);
         }
     }
     else
     {
         if (hasJumped && Input.GetKeyDown(KeyCode.Space))
          {
             Debug.Log("Second Jump");
             anim.SetBool("jump", true);
             hasJumped = false;
             moveDirection.y = jumpSpeed;
          }
     }
     moveDirection.y -= gravity * Time.deltaTime;
     controller.Move(moveDirection * Time.deltaTime);
 }
  [1]: http://answers.unity.com/answers/643243/view.html
