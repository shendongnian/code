    public Rigidbody _body;
    public float Speed;
    
    private void FixedUpdate()
    {
        var currentVelocity = _body.velocity;
        var currentDirection = currentVelocity.normalized;
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");
        
        if(Mathf.Approximately(_body.velocity.magnitude, 0))
        {
            // Directly calculating the velocity as Immersive said:
            // newVelocity = currentVelocity + Time.deltaTime * Force / Mass
            // where Force = direction * Speed
            // 
            // Ofcourse you could also just use AddForce for this case but
            // just for consistency I would use the same method for both cases
            if(vAxis>0) _body.velocity += new Vector3(hAxis, 0.0f, vAxis) * (Time.deltaTime * Speed / _body.mass);
        }
        else
        {
            var forwardForce = Speed * vAxis * currentDirection;
            var sideForce = Speed * hAxis * -1f * Vector3.Cross(currentDirection, Vector3.up);
            // calculate the future velocity directly without using AddForce
            // (see comment above)
            var newVelocity = currentVelocity + (forwardForce + sideForce) * (Time.deltaTime / _body.mass);
            // Only use this velocity if the new direction is still forward
            // otherwise stop
            _body.velocity = Vector3.Dot(currentVelocity, newVelocity) < 0 ? Vector3.zero : newVelocity;
        }
    }
    
