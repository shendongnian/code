    private Rigidbody _rigidbody;
    private float velocity;
    private void Awake ()
    {
        _rigidbody = GetComponemt<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            velocity = _rigidbody.velocity;
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.isKinematic = true;
        }
