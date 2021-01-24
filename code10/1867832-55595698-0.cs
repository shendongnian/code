    // Instantiates a prefab in a circle
    
    public GameObject prefab;
    public int numberOfObjects = 20;
    public float radius = 5f;
    
    void Start() 
    {
        for (int i = 0; i < numberOfObjects; i++)
        {
            float angle = i * Mathf.PI * 2 / numberOfObjects;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle)) * radius;
            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
    // Instantiates a prefab in a grid
    
    public GameObject prefab;
    public float gridX = 5f;
    public float gridY = 5f;
    public float spacing = 2f;
    
    void Start()
    {
        for (int y = 0; y < gridY; y++) 
        {
            for (int x = 0; x < gridX; x++)
            {
                Vector3 pos = new Vector3(x, 0, y) * spacing;
                Instantiate(prefab, pos, Quaternion.identity);
            }
        }
    } 
