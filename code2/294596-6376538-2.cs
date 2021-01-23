    interface IEventRecord
    {
        void Dispatch(IEventDispatcher dispatcher);
    }
    public class EventRecord<TEvent> : IEventRecord where TEvent : IDomainEvent
    {
        TEvent theEvent;
        public EventRecord(TEvent theEvent)
        {
            this.theEvent = theEvent;
        }
        public void Dispatch(IEventDispatcher dispatcher)
        {
            dispatcher.Dispatch(theEvent);
        }
    }
