    // Specific override for the UnityEvent
    [Serializable] public class IntUnityEvent : UnityEvent<int> { }
    public class ListenerInt : ListenerTemplate<int>
    {
        [SerializeField] private EventInt eventInt;
        [SerializeField] private IntUnityEvent intUnityEvent;
    
        // override and populate the two abstract properties
        // with the references from the serialized fields
        public override UnityEvent<int> unityEvent => intUnityEvent;
        public override EventTemplate<int> gameEvent => eventInt;
    }
    
