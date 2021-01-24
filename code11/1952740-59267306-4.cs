    public interface IEventListener<in T>
    {
        void OnEventRaised(T value);
    }
    
