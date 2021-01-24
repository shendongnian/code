    public GameObject prefab;
    public Vector3 pos;
    void Awake()
    {
        for (int i = 0; i < 12; i++)
        {
            Instantiate(prefab, pos, Quaternion.identity);
            pos.x += 0.5f;
        }
    }
