    public class Collisions : MonoBehaviour
    {
        // Show in the Inspector for debug
        [SerializeField] private List<Collider> colliderList = new List<Collider>();
    
        public bool IsTouching => colliderList.Count != 0;
    
        private void Awake ()
        {
            // Make sure list is empty at start
            colliderList.Clear();
        }
    
        private void OnCollisionEnter(Collision collision)
        {
            // Filter out own collider
            if(collision.gameObject == gameObject) return;
    
            if(!colliderList.Contains(collision.collider) colliderList.Add(collision.collider);
        }
    
        private void OnCollisionExit(Collision collision)
        {
            // Filter out own collider
            if(collision.gameObject == gameObject) return;
    
            if(colliderList.Contains(collision.collider) colliderList.Remove(collision.collider);
        }
    }
