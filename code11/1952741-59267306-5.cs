    public abstract class ListenerTemplate<T> : MonoBehaviour, IEventListener<T>
    {
        // These have to be provided by the inheritor
        public abstract UnityEvent<T> unityEvent { get; }
        public abstract EventTemplate<T> gameEvent { get; }
    
        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }
    
        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }
    
        public void OnEventRaised(T value)
        {
            unityEvent.Invoke(value);
        }
    }
    
