    public class EnemyCache : MonoBehaviour {
        // Singleton
        public static EnemyCache Instance { get; private set; }
    
        private List<Enemy> cachedEnemies;
    
        private void Awake() {
            Instance = this;
            cachedEnemies = new List<Enemy>();
            // TODO: Subscribe to a delegate or event, that adds into the 'cachedEnemy' whenever an enemies spawned.
            // Also, an event that removes from 'cachedEnemy' when an enemy dies too.
        }
    
        // ...
    
        /// <summary>
        /// Tries to fetch the first enemy in the cache.
        /// </summary>
        /// <param name="enemy">The fetched enemy; Null if there was nothing in cache</param>
        /// <returns>True if there is an enemy fetched; False if none</returns>
        public bool TryGetFirstEnemy(out Enemy enemy) {
            if (cachedEnemies.Count > 0) {
                enemy = cachedEnemies[0];
                return true;
            }
            enemy = null;
            return false;
        }
    }
