    public float maxDistanceBeforeDestroy = 100f;
   
    ...
    void FixedUpdate()
    {
        // _rigidbody.AddForce(
        //           (Target.position - transform.position).normalized, 
        //           ForceMode.Impulse);
        _rigidbody.velocity = Target.direction.normalized * speed;
        // Check if it has traveled too far
        if ((transform.position - Target.origin).magnitude > maxDistanceBeforeDestroy ) 
        {
            Destroy(gameObject);
        }
    }
