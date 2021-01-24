    private GameObject player;
    public void Awake()
    {
        player = GameObject.Find("player")
    }
    public void Update()
    {
        float distance = player.transform.position.y - FindClosestDirt().transform.position.y;
        //...
    }
    public GameObject FindClosestDirt()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("Dirt");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
