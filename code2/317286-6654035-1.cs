    public class MyEventList<TElementType,TEventArgType>: IList<TElementType> where TEventArgType: EventArgs
    {
        private EventInfo eventInfo;
        private EventHandler<TEventArgType> eventHandler;
        public MyEventList(string eventName, EventHandler<TEventArgType> eventHandler)
        {
            if (eventHandler == null)
                throw new ArgumentNullException("eventHandler");
            if (eventName == null)
                throw new ArgumentNullException("eventName");
            this.eventInfo = typeof(TElementType).GetEvent(eventName);
           
            if (this.eventInfo == null)
                throw new ArgumentException("Specified event not found.", "eventName");
            if (this.eventInfo.EventHandlerType != eventHandler.GetType())
                throw new ArgumentException("EventHandler type does not match specified event.", "eventHandler");
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
