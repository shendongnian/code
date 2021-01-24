    public class SpawnaCasos : MonoBehaviour
    {    
        public GameObject[] Casos;
    
        private GameController gameController;
        private GameObject controller;
        void Start()
        {
            controller = GameObject.FindGameObjectWithTag("Controller");
            gameController = controller.GetComponent<GameController>();
            InstantiateCasos();
        }
    
        void Update()
        {
            if (gameController.contadorPontos == 14)
                InstantiateCasos();
        }
        void InstantiateCasos(){
            Instantiate(Casos[UnityEngine.Random.Range(0, 8)], transform.position, transform.rotation);
        }
    }
