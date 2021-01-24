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
    
    public class B : MonoBehaviour
    {
        // either reference it in the Inspector
        public A a;
    
        private void Awake()
        {
            // or get it somehow on runtime
            a = FindObjectOfType<A>();
    
            // if ready directly move on otherwise add callbacks
            if(a.isReady)
            {
                OnAReady();
            }
            else
            {
                a.OnReady -= OnAReady;
                a.OnReady += OnAReady;
            }
        }
    
        private void OnDestroy()
        {
            // always remove callbacks when no longer needed
            a.OnReady -= OnAReady;
        }
    
        private void OnAReady()
        {
            // always remove callbacks when no longer needed
            a.OnReady -= OnAReady;
            // use stuff from A
        }
    }
