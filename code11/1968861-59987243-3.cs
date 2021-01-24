    private void Start()
    {
        // second parameter is the initial delay
        // last parameter the repeat interval
        InvokeRepeating(nameof(Spawn), 0, 1.0f);
    }
    private void Spawn()
    {
        Vector3 position = new Vector3(Random.Range(-1.88f, 2.1f), Random.Range(-7.81f, -3.1f));
        Instantiate(Prefabs[Random.Range(0, Prefabs.Length)], position, Quaternion.identity);
    }
