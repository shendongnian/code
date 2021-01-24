    if(!controller.isGrounded)
    {
        //Three degree's
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), 
                                    Input.GetAxis("Thrust"), 
                                    Input.GetAxis("Vertical"));
        moveDirection *= speed;
        // collect inputs
        float yaw = Input.GetAxis("Yaw") * rotationSpeed;
        float pitch = Input.GetAxis("Vertical") * tiltAngle;
        float roll = -1 * (Input.GetAxis("Horizontal") * tiltAngle);
 
        // Get current forward direction projected to plane normal to up (horizontal plane)
        Vector3 forwardCurrent = transform.forward 
                                - Vector3.Dot(transform.forward,Vector3.up) * Vector3.up;
        // Debug to view forwardCurrent
        Debug.DrawRay(transform.location, forwardCurrent, Color.white, .01f, false);
        // create rotation based on forward
        Quaternion targetRotation = Quaternion.LookRotation(forwardCurrent);
        // rotate based on yaw, then pitch, then roll. 
        // This order prevents changes to the projected forward direction
        targetRotation = targetRotation * Quaternion.AngleAxis(yaw, Vector3.up);
        // Debug to see forward after applying yaw
        Debug.DrawRay(transform.location, Vector3.forward * targetRotation, Color.red, .01f, false);
        targetRotation = targetRotation * Quaternion.AngleAxis(pitch, Vector3.right);
        targetRotation = targetRotation  * Quaternion.AngleAxis(roll, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, smooth);
        controller.Move(moveDirection * Time.deltaTime);
    }
