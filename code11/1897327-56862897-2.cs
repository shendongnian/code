    public class SpawntoLerp : MonoBehaviour
    {
        // you can use any Component as field
        // and Unity will automatically take the according reference
        // from the GameObject you drag in
        public Transform CubePrefab;
        public Transform instance;
    
        // Do not call it transform as this property already exists in MonoBehaviour
        public Transform PointCopy;
    
        private void Start()
        {
            // instantiate automatically returns the same type
            // as the given prefab
            instance = Instantiate(CubePrefab, transform.position, transform.rotation);
        }
    
        private void Update()
        {
            instance.position = Vector3.MoveTowards(instance.position, PointCopy.position, 5f * Time.deltaTime);
        }
    }
