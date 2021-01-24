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
                // it is always good to remove the callback even though
                // it wasn't added yet. Makes sure it is always only added once
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
