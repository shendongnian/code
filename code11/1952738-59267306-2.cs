    // Specific override for the UnityEvent
    [Serializable] public class IntEvent : UnityEvent<int> { }
    public class ListenerInt : ListenerTemplate<int>
    {
        [SerializeField] private EventInt eventInt;
        [SerializeField] private IntEvent intEvent;
    
        // override and populate the two abstract properties
        // with the references from the serialized fields
        public override UnityEvent<int> unityEvent => intEvent;
        public override EventTemplate<int> gameEvent => eventInt;
    }
    
