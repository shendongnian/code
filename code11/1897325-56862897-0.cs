    public class SpawntoLerp : MonoBehaviour
    {
        public GameObject CubePrefab;
        public Transform instance;
    
        // Do not call it transform as this property already exists in MonoBehaviour
        public Transform PointCopy;
    
        private void Start()
        {
            instance = Instantiate(CubePrefab, transform.position, transform.rotation).transform;
        }
    
        private void Update()
        {
            instance.transform.position = Vector3.MoveTowards
                (instance.transform.position, PointCopy.position, 5f * Time.deltaTime);
        }
    }
