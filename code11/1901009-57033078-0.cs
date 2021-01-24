    public class GameManager : MonoBehaviour
    {
         private void Awake()
         {
            if (instance == null)
            {
                instance = this;
            }
         DontDestroyOnLoad(this);
         }
        void Start()
        {
            shapeSpawnerGO = GameObject.Find("SpawnShapesObj");
            scoreGO = GameObject.Find("ScoreText");
            lifeGo = GameObject.Find("LifeText");
        }
    }
    
