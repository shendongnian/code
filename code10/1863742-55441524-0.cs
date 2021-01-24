    public Transform Target;
    public float Speed = 1f;
    public Vector3 Offset;
    void Update()
    {
        // Compute the position the object will reach
        Vector3 desiredPosition = Target.rotation * (Target.position + Offset);
        // Compute the direction the object will look at
        Vector3 desiredDirection = Vector3.Project( Target.forward, (Target.position - desiredPosition).normalized );
        // Rotate the object
        transform.rotation = Quaternion.Slerp( transform.rotation, Quaternion.LookRotation( desiredDirection ), Time.deltaTime * Speed );
        // Place the object to "compensate" the rotation
        transform.position = Target.position - transform.forward * Offset.magnitude;
    }
