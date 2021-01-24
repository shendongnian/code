    public class CollisionHandler : MonoBehaviour
    {
        public bool CanMove;
        void OnTriggerEnter(Collider other)
        {
            CanMove = false;
        }
        void OnTriggerExit(Collider other)
        {
            CanMove = true;
        }
    }
    
