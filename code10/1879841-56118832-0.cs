    public GameObject[] Enemies;
    public void Awake()
    {
    Enemies = FindObjectsOfType<[YourEnemyScriptName]>(); // Insert your Enemies script name inside [].
    }
    void Start(){
        SpawnTheEnemies();
    }
    public void SpawnTheEnemies()
    {
        int Rand = Random.Range(0, Enemies.Length);
        GameObject Buildings = Instantiate(Enemies[Rand], transform.position,         Quaternion.Euler(0, Random.Range(0, 360), 0));
            Buildings.transform.parent = gameObject.transform;
    }
