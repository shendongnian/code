    private IEnumerator coroutine;
    void Start()
    {
        coroutine = SpawnClone(5.0f);
        StartCoroutine(coroutine, 5.0f); //Trigger SpawnClone coroutine and pass in the delay of 5 seconds
        print("Triggered Coroutine SpawnClone");
    }
    private IEnumerator SpawnClone(float delay)
    {
        print("Coroutine tick");
        yield return new WaitForSeconds(delay);
        
        print("Coroutine logic stared: " + Time.time + " seconds");
        Vector3 originalPosition = new Vector3(Random.Range(-5f, 5f), Random.Range(-2, 2), 100);
        Rigidbody clone;
        clone = Instantiate(original, originalPosition, transform.rotation);
        clone.velocity = rb.velocity * speed;   
        
        print("Coroutine ended: " + Time.time + " seconds");     
    }
