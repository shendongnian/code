    void Start()
    {
        go1 = Instantiate(M1, new Vector3(Random.Range(-5, 5), Random.Range(6, 15), 0), Quaternion.Euler(0, 0, 0)) as GameObject;
    }
    void Update()
    { 
        Rigidbody2D rg = go1.GetComponent<Rigidbody2D>();
        rg.AddForce(new Vector2(10, -15));
    }
