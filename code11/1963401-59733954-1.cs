    private int size;
    
    void Awake()
    {
        size = (Prefabs.Length < spawnPoint.Length) ? Prefabs.Length : spawnPoint.Length;
    }
    
    void OnTriggerEnter(Collider other) 
    {
        for (int i = 0; i < size; i++)
        {
            GameObject clone = Instantiate(Prefab[i], spawnPoint[i].position, spawnPoint[i].rotation);
            Destroy(clone, delay);
        }
    }
