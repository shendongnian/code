    public float deg = 0;
    public GameObject go;
    public Vector3 cenLocal;
    public Rigidbody rb;
    
    void Start ()
    {
        deg = 0;
        go = this.gameObject;
    
        rb = go.GetComponent<Rigidbody>();
        cenLocal = go.GetComponent<BoxCollider>().center; // Center (local space)
    }
    
    private void FixedUpdate()
    {
        deg += 1f;
    
        if (deg >= 360f) deg = 0;
    
    
        Vector3 cenGlobal = go.transform.TransformPoint(cenLocal); // Center (global space)
    
        go.transform.RotateAround(cenGlobal , Vector3.up, deg);
    
    
    }
