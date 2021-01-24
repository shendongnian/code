    public class CollisionHandler : MonoBehaviour
    {
        public bool CanMove;
        void OnTriggerEnter(Collision other)
        {
            CanMove = false;
        }
        void OnTriggerExit(Colider other)
        {
            CanMove = true;
        }
    }
    
