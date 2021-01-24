    public class YourMissileSpawner : MonoBehaviour {
        [SerializeField]
        private YourMissile missilePrefab;
    
        // ...
    
        public void SpawnProjectile() {
            YourMissile newMissile = Instantiate(missilePrefab);
    
            // Set position... etc...
    
            // Try to get a target for the new missile
            if (EnemyCache.Instance.TryGetFirstEnemy(out Enemy enemyToTarget)) {
                newMissile.SetTarget(enemyToTarget.gameObject);
            } else {
                Debug.LogWarning("No enemy for newly spawned missile to target!");
            }
    
            // NOTE: The above is optional,
            // since 'YourMissile' sets a new target from EnemyCache
            // if the target is null; (checks per update)
    
            // But I included it here in case you want it to filter
            // what kind of enemy it needs to target on start :)
        }
    }
