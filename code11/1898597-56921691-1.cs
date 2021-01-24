    public class SpawnObjects : MonoBehaviour
    {
    
        public Transform pickUp;
        public Transform[] spawnPoints;
        public float Timer = 10;
    
        void Start()
        {
            if (spawnPoints.Length == 0)
            {
                Debug.LogError("No spawn points referenced.");
            }
        }
    
        void Update()
        {
            Timer -= Time.deltaTime;
    
            if (Timer <= 0)
            {
                Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
                GameObject instance = Instantiate(pickUp, _sp.position, _sp.rotation).gameObject;
                Destroy(instance, 15);
                Timer = 10;
            }
        }
    }
