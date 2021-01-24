    public abstract class EventTemplate<TValue> : ScriptableObject
    {
        private readonly List<IEventListener<TValue>> listeners = new List<IEventListener<TValue>>();
    
        public void Raise(TValue go)
        {
            // actually why iterate backwards?
            for (int i = listeners.Count - 1; i >= 0; i--)
            {
                listeners[i].OnEventRaised(go);
            }
        }
    
        public void RegisterListener(ListenerTemplate<TValue> listener)
        {
            listeners.Add(listener);
        }
    
        public void UnregisterListener(ListenerTemplate<TValue> listener)
        {
            listeners.Remove(listener);
        }
    }
