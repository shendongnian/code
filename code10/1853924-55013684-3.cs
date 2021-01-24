    public class GameManager2 : MonoBehaviour
    {
        public GameObject cubePrefab;
        private void Start()
        {
            Invoke("SpawnCube", 1);
        }
        void SpawnCube()
        {
            GameObject spawnedCube2 = Instantiate(cubePrefab, Vector3.zero, Quaternion.identity);
            Debug.Log("Cube2 A = " + spawnedCube2.GetComponent<Cube>().A);
        }
    }
