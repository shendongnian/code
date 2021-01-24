    public class GameManager1 : MonoBehaviour
    {
        public GameObject cubePrefab;
        public Cube cubeComponent;    
        void Start()
        {
            cubeComponent.A = 10;
            GameObject spawnedCube = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
            Debug.Log("A = " + spawnedCube.GetComponent<Cube>().A); //Prints 10
        }
    }
