    public class Spawner : MonoBehaviour
    {
    
        public GameObject[] chickens;
        public Vector3 spawnValues;
        public float spawnWait;
        public float spawnMostWait;
        public float spawnLeastWait;
        public int startWait;
        public bool stop;
    
        int randEnemy;
    
        void Start()
        {
            StartCoroutine(waitSpawner());
        }
    
        void Update()
        {
            spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
        }
    
        IEnumerator waitSpawner()
        {
            yield return new WaitForSeconds(startWait);
    
            while (!stop)
            {
                randEnemy = Random.Range(0, 2);
                Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), Random.Range(-spawnValues.y, spawnValues.y), -3);
                Instantiate(chickens[randEnemy], spawnPosition + transform.TransformPoint(0, 0, 0), gameObject.transform.rotation);
    
                yield return new WaitForSeconds(spawnWait);
            }
        }   
    }
