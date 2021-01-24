    public interface IEvent { // empty, just a marker interface }
    public class AccountRegisteredEvent : IEvent {
        public Guid AccountGuid { get; private set; }
        public Email AccountEmail { get; private set; }
        public string UserName { get; private set; } 
    }
    public class CommentAdded : IEvent {
        public GuidAccountGuid { get; private set; }
        public string Comment { get; private set; }
    }
    public class EventHistory {
        private readonly Queue<IEvent> mEvents;
        public void Enqueue(IEvent event) { ..... }
        
        public IEvent Dequeue() {
            return mEvents.Dequeue();
        }
    }
    public class EventProcessor {
        private Dictionary<Type, Action<IEvent> mEventTypeHanlerMap;
        public EventProcessor() {
            mEventTypeHandlerMap = new Dictionary<Type, Action<IEvent>();
        
            meventTypeHandlerMap.Add(
                typeof(AccountAddedEvent),
                ProcessAccountAdded);
            // add other event handlers
        }
        public void Process(IEvent event) {
            var handler = mEventTypeHanlerMap[event.GetType()];
            handler(event);
        }
        private void ProcessAccountAdded(IEvent event) {
            var accountAddedEvent = (AccountAddedEvent)event;
            // process
        }
        private void ProcessCommentAdded(IEvent event) {
            var commentAdded = (CommentAddedEvent)event;
            // process
        }
    }
