    void Start()
    {
        Invoke("SpawnClone", 5.0f); //Call SpawnClone 5 seconds after start
    }
    void SpawnClone()
    {
        print("fixed clone");
        Vector3 originalPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-2, 2), 100);
        
        Rigidbody clone;
        clone = Instantiate(original, originalPosition, transform.rotation);
        clone.velocity = rb.velocity * speed;
    }
