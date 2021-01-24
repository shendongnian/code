        [CreateAssetMenu(menuName = "EnemySpawner")]
        public class EnemySpawner : ScriptableObject
        {
            public event Action<Enemy> OnSpawn;
            
            public Enemy enemyPrefab;
    
            public void SpawnEnemyWithSword()
            {
                var enemy = Instantiate(enemyPrefab);
                //..
                //code to setup sword 
                //..
                OnSpawn?.Invoke(enemy);
            }
            
            public void SpawnEnemyWithAxe()
            {
                //any other logic with the same event
            }
        }
