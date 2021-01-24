    [Serializable]
    public class WeightedPrefab
    {
        public GameObject Prefab;
        public int Weight = 1;
    }
    public List<WeightedPrefab> weightedEnemyPrefabs;
    private void GenerateEnemies(...)
    {
        ...
        // create a temp list
        var enemyPrefabs = new List<GameObject>();
        foreach(var item in weightedEnemyPrefabs)
        {
            for(var i = 0; i < item.Weight; i++)
            {
                enemyPrefabs.Add(item.Prefab);
            }
        }
        
        // Rest stays the same
    }
