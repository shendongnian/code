    [Serializable]
    public class WeightedPrefab
    {
        public GameObject Prefab;
        public int Weight = 1;
    }
    public List<WeightedPrefab> weightedEnemyPrefabs;
    public Gamebject playerPrefab;
    public GameObject endGamePrefab;
    private void GenerateEnemies(int xMax, int zMax)
    {
        // create a temp list using the weights and random index on this one
        var enemyPrefabs = new List<GameObject>();
        foreach(var item in weightedEnemyPrefabs)
        {
            for(var i = 0; i < item.Weight; i++)
            {
                enemyPrefabs.Add(item.Prefab);
            }
        }
        
        // Rest stays the same
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
                if(enemyPrefab) Instantiate(enemyPrefab, new Vector3(x * 10, 0, z * 10), Quaternion.identity /*, landscape.transform*/);
            }
        }
    }
