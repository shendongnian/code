    public class ObjectController : MonoBehaviour
    {
        // Here we will store all Transform references
        // linked to the according target position
        private Dictionary<Transform, Vector3> objects = new Dictionary<Transform, Vector3>();
    
        public GameObject prefab;
        
        // A simple timer for the spawning
        private float timer;
    
        // Here we will track objets that reached the Target and shall be destroyed
        List<GameObject> objectsToDestroy = new List<GameObject>();
    
        private void Update()
        {
            // Spawn a new object every second but only until maximum of 10 existing objects
            if(objects.Keys.Length < 10)
            {
                timer += Time.deltaTime;
                if(timer > 1f)
                {
                    timer = 0;
    
                    // However you generate your random start Position
                    Vector3 startPos = GetRandomStartPosition();
                    // However you generate your random target position
                    Vector3 targetPos = GetRandomTargetPosition(startPos);
                    var obj = Instantiate(prefab, startPos, Quaternion.Identity).transform;
    
                    // Add this new transform and according target Position to the dictionary
                    objects.Add(obj, targetPos);
                }
            }
    
            objectsToDestroy.Clear();
            // Now go through the items in objects and move them all
            foreach(var kvp in objects)
            {
                var obj = kvp.Key;
                obj.MoveTowards(obj.position, kvp.Value, 0.05f * Time.deltaTime);
    
                // Do NOT use collisions for detecting if the object reaches but directly this
                if(obj.position == kvp.Value)
                // this uses a proximity of 0.00001f if you really need 0 instead use
                //if(Mathf.Approximately(Vector3.Distance(obj.position, kvp.Value), 0))
                {
                    // mark this object for removal
                    objectsToDestroy.Add(obj);
                }
            }
    
            // Finally remove all objects that reached from the dict and destroy them
            foreach(var obj in objectsToDestroy)
            {
                objects.Remove(obj);
                Destroy(obj);
            }
        }
    }
