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
        
            void OnCollisionEnter(Collision collision)
            {
                enemyBehavior evade = collision.collider.GetComponent<enemyBehavior>();
                if (collision.gameObject.name == "coin")
                {
                    Destroy(collision.gameObject);
                    enemyBehavior script = GetComponent<enemyBehavior>();
                    script.evade = script.evade == true;
                }
            }
        }
