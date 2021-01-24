    private Rigidbody _rigidbody;
    private float velocity;
    private void Awake ()
    {
        _rigidbody = GetComponemt<Rigidbody>();
    }
    private bool isFrozen;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            isFrozen = !isFrozen;
            if(isFrozen) velocity = _rigidbody.velocity;
            _rigidbody.velocity = isFrozen ? Vector3.zero : velocity;
            _rigidbody.isKinematic = isFrozen;
        }
    }
