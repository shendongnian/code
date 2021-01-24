    public GameObject[] Spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        foreach (GameObject spawn in Spawner)
        {
            Instantiate(spawn);
        }
    }
