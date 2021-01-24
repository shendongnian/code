    public class enemyBehavior : MonoBehaviour
        {
            public bool evade = false;
            public GameObject Player;
            public float movementSpeed = 4;
        
            void Start()
            {
                Player = GameObject.FindGameObjectWithTag("Player");
            }
            void Update()
            {
                transform.LookAt(Player.transform);
                transform.position += transform.forward * movementSpeed * Time.deltaTime;
        
                if (evade)
                {
                    movementSpeed = -4;
                }
            }
        }
    
        public class playerMechanics : MonoBehaviour
        {
            [SerializeField] enemyBehvaior enemy;
        
            void OnCollisionEnter(Collision collision)
            {
                if (collision.collider.name == "coin")
                {
                    Destroy(collision.collider.gameObject);
                    enemy.evade = true;
                }
            }
        }
