    public class Respawn : MonoBehaviour
    {
        public GameObject Player;
        private Vector3 startPosition;
    
        void Start() 
        {
            startPosition = Player.transform.position;
        }
    
        void Update()
        {
           if(Player.isDead())
           {
               Player.transform.position = startPosition;
           }
        }
    }
