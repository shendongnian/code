    public class CollisionHandler : MonoBehaviour
    {
        public bool CanMove;
        void OnCollisionEnter(Collision other)
        {
            CanMove = false;
        }
        void OnCollisionExit(Collision other)
        {
            CanMove = true;
        }
    }
    
