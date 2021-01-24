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
            if(vAxis>0) _body.velocity += new Vector3(hAxis, 0.0f, vAxis) * (Time.deltaTime * Speed / _body.mass);
        }
        else
        {
            var forwardForce = Speed * vAxis * currentDirection;
            var sideForce = Speed * hAxis * -1f * Vector3.Cross(currentDirection, Vector3.up);
            var newVelocity = currentVelocity + (forwardForce + sideForce) * (Time.deltaTime / _body.mass);
            _body.velocity = Vector3.Dot(currentVelocity, newVelocity) < 0 ? Vector3.zero : newVelocity;
        }
    }
    
