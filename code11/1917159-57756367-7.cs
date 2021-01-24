    public class RayReceiver : MonoBehaviour
    {
        public bool isHitByRay = false;
    
        private void Start()
        {
            isHitByRay = false;
        }
    
        public void HitWithRay()
        {
            isHitByRay = true;
        }
    
        public void ResetFlag()
        {
            isHitByRay = false;
        }
    }
