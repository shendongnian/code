    public class RayReceiverScript : MonoBehaviour
    {
        const float hitByRayRefreshTime = .01f;
        private float rayRunsOutTime;
        public bool isHitByRay = false;
    
        void Start()
        {
            rayRunsOutTime = Time.time;
        }
    
        public void HitWithRay()
        {
            isHitByRay = true;
            rayRunsOutTime = Time.time + hitByRayRefreshTime;
        }
        public void ResetFlag()
        {
            isHitByRay  = false;
        }
    }
