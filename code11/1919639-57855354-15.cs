    [Serializable]
    public class WeightedPrefab
    {
        public GameObject Prefab;
        public int Weight = 1;
    }
    
    public List<WeightedPrefab> weightedEnemyPrefabs;
    public Gamebject playerPrefab;
    public GameObject endGamePrefab;
    private void GenerateEnemies(...)
    {
        // Create a list of all awailable grid positions
        var List<Vector2Int> gridPositions = new List<Vector2Int>();
        for (int z = 0; z < zMax; z++)
        {
            for (int x = 0; x < xMax; x++)
            {
                gridPositions.Add(new Vector2Int(x,z));
            }
        }
 
        // pick the two random positions for player and endgame
        var playerPosIndex = Random.Range(0, gridPositions.Count);
        var playerPos = gridPositions[playerPosIndex];
        gridPositions.RemoveAt(playerPosIndex);
        var endGamePosIndex = Random.Range(0, gridPositions.Count);
        var endGamePos = gridPositions[endGamePosIndex];
        gridPositions.RemoveAt(endGamePosIndex);
        // create a temp list using the weights and random index on this one
        var enemyPrefabs = new List<GameObject>();
        foreach(var item in weightedEnemyPrefabs)
        {
            for(var i = 0; i < item.Weight; i++)
            {
                enemyPrefabs.Add(item.Prefab);
            }
        }
    
        var landscape = new GameObject("ENEMIES");
    
        // Do these only once
        // store the references in case you need them later
        var player = Instantiate(playerPrefab, new Vector3(payerPos.x * 10, 0, playerPos.y * 10), Quaternion.identity /*, landscape.transform*/);
        var endGame = Instantiate(endGamePrefab, new Vector3(endGamePos.x * 10, 0, endGamePos.y * 10), Quaternion.identity /*, landscape.transform*/);
    
        for (int z = 0; z < zMax; z++)
        {
            for (int x = 0; x < xMax; x++)
            {
                // Now simply ignore the playerPos and endGamePos
                if(x == playerPos.x && z == playerPos.y) continue;
                if(x == endGamePos.x && z == endGamePos.y) continue;
                // pick a random index from the prefab list
                int randIndex = Random.Range(0, eneymPrefabs.Count);
    
                // and get the according random prefab
                var enemyPrefab = enemyPrefabs[randIndex];
    
                // do nothing if enemyPrefab is null otherwise instantiate
                if(enemyPrefab) Instantiate(enemyPrefab, new Vector3(x * 10, 0, z * 10), Quaternion.identity /*, landscape.transform*/);
            }
        }
    }
