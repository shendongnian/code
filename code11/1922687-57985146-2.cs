    // Adjust in the Inspector
    [SerializeField] private float range = 10;
    // Stores the initial position
    private Vector3 startPosition;
    private void Start()
    {
        // Store position before starting to move
        startPosition = transform.position;
    }
    private void Update ()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
        // Directly compare to the initial position
        // Without having to care who fired this ball
        if(Mathf.Abs(startPosition.z - transform.position.z) >= range)
        {
            Destroy(gameObject);
        }
        // Or simply
        if(Vector3.Distance(startPosition, transform.position) >= range)
        {
            Destroy(gameObject);
        }
    }
