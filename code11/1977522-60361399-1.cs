    public class GameManagement : MonoBehaviour
    {
        // Give this field the correct type
        public EnemyController circleEnemie;
    
        public Transform player;
        [SerializeField]
        float moveSpeed = 1;
        // Start is called before the first frame update
        void Start()
        {
            //Get random position to spawn ball
            Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(Random.Range(0, Screen.width), Random.Range(0, Screen.height), Camera.main.farClipPlane / 2));
            // Instantiate returns the same type as the given prefab
            EnemyController enemy = Instantiate(circleEnemie, screenPosition, Quaternion.identity);
            enemy.name = "enemiecircle";
            enemy.gameObject.tag = "Enemie";
    
            // Now pass in the player reference
            enemy.player = player;
        }
    
        // NOTE: When not needed better remove Unity message methods
        // It would just cause overhead
        //void Update()
        //{
        //}
    }
