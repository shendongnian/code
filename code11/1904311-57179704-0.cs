    public class CollisionTracker : MonoBehaviour
    {
        Collision collision;
    
        void Update()
        {
            if (collision != null && collision.gameObject.tag == "Player")
            {
                Debug.Log("Colliding with Player!");
            }
        }
    
        void OnCollisionEnter(Collision collision)
        {
            this.collision = collision;
        }
    
        void OnCollisionExit(Collision collision)
        {
            this.collision = null;
        }
    }
