    public class EventRecord
    {
        EventRecord() { }
        Action<IEventDispatcher> RaiseDelegate { get; set; }
        public static EventRecord Create<TEvent>(TEvent theEvent) where TEvent : IDomainEvent
        {
            var record = new EventRecord();
            record.RaiseDelegate = dispatcher => dispatcher.Dispatch(theEvent);
            return record;
        }
        public void Raise(IEventDispatcher dispatcher)
        {
            RaiseDelegate(dispatcher);
        }
    }
