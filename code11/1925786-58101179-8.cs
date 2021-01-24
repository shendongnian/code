    public class levelgen : MonoBehaviour
    {
        public GameObject[] templates;
        public Vector3 spawn;
        int zPosition = 0;
        void Start()
        {
            GenerateObstacles(10);
        }
    
        void GenerateObstacles (int numObstacles)
        {
            for (int i = 0; i < numObstacles; i++)
            {
                spawn = new Vector3(-2, 0, zPosition);
                int rand = Random.Range(0, 6); //1-5 types of levels
                Instantiate(templates[rand], spawn, Quaternion.identity);
                zPosition += 20;
            }
        }
    }
