    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public GameObject prefabToDestroy;
        public GameObject prefabToSpawn;
    
        public void Start()
        {
           DestroyAndSpawn(prefabToDestroy, prefabToSpawn);
        }
    
        public void DestroyAndSpawn(GameObject prefabToDestroy, GameObject prefabToSpawn)
        {
           Vector3 position = prefabToDestroy.transform.position;
           Destroy(prefabToDestroy);
           Instantiate<GameObject>(prefabToSpawn, position, Quaternion.Identity);
        }
    }
