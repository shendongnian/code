    public GameObject[] Prefab;
    public Transform[] spawnPoint;
    private float delay = 3f;
    
    void OnTriggerEnter(Collider other) 
    {
        for (int i = 0; i < Prefabs.Length; i++)
        {
            GameObject clone = Instantiate(Prefab[i], spawnPoint[i].position, spawnPoint[i].rotation);
            Destroy(clone, delay);
        }
    }
