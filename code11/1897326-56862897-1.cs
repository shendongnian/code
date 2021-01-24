    public class SpawntoLerp : MonoBehaviour
    {
        public GameObject CubePrefab;
        public Transform PointCopy;
    
        private void Start()
        {
            StartCoroutine(SpawnAndMove(CubePrefab, PointCopy.position));
        }
    
        private IEnumerator SpawnAndMove(GameObject prefab, Vector3 targetPosition)
        {
            Transform instance = Instantiate(CubePrefab, transform.position, transform.rotation).transform;
            while(Vector3.Distance(instance.position, targetPosition) > 0)
            {
                instance.transform.position = Vector3.MoveTowards
                    (instance.transform.position, targetPosition, 5f * Time.deltaTime);
                // "Pause" the routine, render this frame and 
                // continue from here in the next frame
                yield return null;
            }
        }
    }
