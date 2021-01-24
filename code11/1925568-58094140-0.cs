    void FixedUpdate()
    {
        if(rotateStatus)
        {
             rb.transform.Rotate(0, 45, 0, Space.World);
             // Also tried it with;
             // rb.MoveRotation(rb.rotation * Quaternion.Euler(Vector3.up * rotationSpeed * Time.deltaTime));
             Debug.Log("Rotation should been happend.");
        }
     }
