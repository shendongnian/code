    public class A : MonoBehaviour
    {
        public event Action OnReady;
        public bool isReady;
    
        private void Awake()
        {
            // do your stuff
    
            isReady = true;
            // execute whatever was added as callback
            OnReady?.Invoke();
        }
    }
