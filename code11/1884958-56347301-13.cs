    public float maxDistanceBeforeDestroy = 100f;
   
    ...
    void FixedUpdate()
    {
        if (isHoming) 
        {    
            // _rigidbody.AddForce((Target.position - transform.position).normalized, ForceMode.Impulse);
            Collider targetCollider = Target.GetComponent<Collider>();
            Vector3 targetDirection;
            if (targetCollider)
                targetDirection = targetCollider.ClosestPoint(transform.position) - transform.position;
            else
                targetDirection = Target.position - transform.position;
    
            _rigidbody.velocity = targetDirection.normalized * speed;
            if (Vector3.Distance(transform.position, Target.position) < 1.0f)
            {
                //make the explosion
                GameObject ThisExplosion = Instantiate(Explosion, gameObject.transform.position, gameObject.transform.rotation) as GameObject;
    
                //destory the projectile
                Destroy(gameObject);
            }
        }
        else
        {
            _rigidbody.velocity = TargetRay.direction.normalized * speed;
    
            // Check if it has traveled too far
    
            if ((transform.position - TargetRay.origin).magnitude > maxDistanceBeforeDestroy ) 
            {
                Destroy(gameObject);
            }
        }
    }
