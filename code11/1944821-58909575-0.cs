    // If anyhow possible already reference these via the Inspector
    // by drag&drop, then you can completely skip the Find and GetComponent
    [SerializeField] private Transform _destination;
    [SerializeField] private Rigidbody _rigidbody;
    
    private bool rigidbodyIsKinematic;
    private void Start()
    {
        if(!_destination) _destination = GameObject.Find("Destination").transform;
        if(!_rigidbody) _rigidbody = GetComponent<Rigidbody>();
    }
    
    void Update()
    {
        distance = Vector3.Distance(transform.position, TheDest.transform.position);
        if(distance >= 1f)
        {
            isHolding = false;
            Debug.Log("Too far from object to pick it up!");
        }
    
        //check if is holding
        if (isHolding)
        {
            // This should actually never happen
            if(!_rigidbody) _rigibody = GetComponent<Rigidbody>();
            // The following block shall only be called once
            if(!_rigidbody.isKinematic)
            {
                _rigidbody.velocity = Vector3.zero;
                _rigidbody.angularVelocity = Vector3.zero;
                _rigidbody.isKinematic = true;
    
                // also this should actually never happen
                if(!_destination) _destination = GameObject.Find("Destination").transform;
    
                // Why are you doing this at all?
                // Note that later you never undo this
                transform.parent = _destination;
            }
            transform.position = TheDest.position;
    
            // Check if 1 is the correct button index
            if (Input.GetMouseButtonDown(1))
            {
                _rigidbody.isKinematic = false;
                // question: should this really be TheDest.forward ?
                // or maybe the direction from this object to Destination which would rather be
                // Destination.position - transform.position
                _rigidbody.AddForce(TheDest.forward * throwForce);
                isHolding = false;
                Debug.Log("Object was thrown!");
            }
        }
    }
    
