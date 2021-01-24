    if (grounded) 
    {
      vector = Vector3.zero;
    
      if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
      {
         vector += Vector3.forward;
      }
      else if (Input.GetKey(KeyCode.S) && !Input.GetKey(KeyCode.W))
      {
         vector += Vector3.back;
      }
    
      if (Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
      {
         vector += Vector3.left;
      }
      else if (Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
      {
         vector += Vector3.right;
      }
    }
    
    transform.Translate(vector.normalized * movementSpeed * Time.deltaTime);
