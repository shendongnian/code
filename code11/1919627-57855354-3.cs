    // HINT: Rather have a list for your prefabs
    // this shrinks your code a lot
    public List<GameObject/*or whatever type*/> eneymPrefabs = new List<GameObject>();
    public Gamebject playerPrefab;
    public GameObject endGamePrefab;
    private void GenerateEnemies(int xMax, int zMax)
    {
        var landscape = new GameObject("ENEMIES");
        // Do these only once
        // store the references in case you need them later
        var player = Instantiate(playerPrefab);
        var endGame = Instantiate(endGamePrefab);
        for (int z = 0; z < zMax; z++)
        {
            for (int x = 0; x < xMax; x++)
            {
                // simply pick a random index from the prefab list
                int randIndex = Random.Range(0, eneymPrefabs.Count);
                // and get the according random prefab
                var enemyPrefab = enemyPrefabs[randIndex];
                Instantiate(enemyPrefab, new Vector3(x * 10, 0, z * 10), Quaternion.identity /*, landscape.transform*/);
            }
        }
    }
