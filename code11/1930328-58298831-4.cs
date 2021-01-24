    public Rigidbody _body;
    public float Speed;
    // store the last forward direction
    private Vector3 lastForward;
    private void FixedUpdate()
    {
        // Check and clamp the current velocity against the last one
        // so after forces from last call have been applied
        if (Vector3.Dot(lastForward, _body.velocity.normalized) < 0)
        {
            Debug.Log("Clamped negative");
            _body.velocity = Vector3.zero;
        }
        lastForward = _body.velocity.normalized;
        
        var hAxis = Input.GetAxis("Horizontal");
        var vAxis = Input.GetAxis("Vertical");
        
        // == for Vector3 has only a precision of 0.00001
        // to be sure you coul use this instead
        if (Mathf.Approximately(_body.velocity.magnitude, 0))
        {
            if (vAxis > 0) _body.AddForce(new Vector3(hAxis, 0.0f, vAxis) * Speed);
        }
        else
        {
            var forwardForce = Speed * vAxis * lastForward;
            var sideForce = Speed * hAxis * -1f * Vector3.Cross(lastForward, Vector3.up);
            _body.AddForce(forwardForce + sideForce);
        }
    }
    
