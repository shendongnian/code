    public class MyEventList<TElementType,TEventArg>: IList<T> where TEventArg: EventArgs
    {
        private EventInfo eventInfo;
        private EventHandler<TEventArg> eventHandler;
        public MyEventList(string eventName, EventHandler<Q> eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("eventHandler");
            if (eventName == null)
                throw new ArgumentNullException("eventName");
            this.eventInfo = typeof(T).GetEvent(eventName);
           
            if (this.eventInfo == null)
                throw new ArgumentException("Specified event not found.", "eventName");
            this.eventHandler = eventHandler;
        }
        public void Add(TElementType item)
        {
            ...
            eventInfo.AddEventHandler(item, this.eventHandler);
            ...
        }
        public bool Remove(TElementType item)
        {
            ...
            eventInfo.RemoveEventHandler(item, this.eventHandler);
            ...
        }
         
        ...
     }
