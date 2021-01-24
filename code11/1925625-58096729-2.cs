    public class PortalBorder : MonoBehaviour
    {
        public UnityEvent OnEnteredPortalRange;
        public UnityEvent OnLeftPortalRange;
    
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnEnteredPortalRange.Invoke();
            }
        }
    
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                OnEnteredPortalRange.Invoke();
            }
        } 
    }
