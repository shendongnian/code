    class MyEventWrapper
    {
        public event EventDelegate Handlers;
        public void Raise(object sender, EventArgs args)
        {
            Handlers?.Invoke(sender, args);
        }
    }
    //
    Dictionary<EventTypes, MyEventWrapper> eventMap = new Dictionary<EventTypes, MyEventWrapper>
    {
        { EventTypes.Event1, new MyEventWrapper() },
        { EventTypes.Event2, new MyEventWrapper() },
    };
    //
    eventMap[EventTypes.Event1].Handlers += (s, a) => { };
    eventMap[EventTypes.Event2].Handlers += (s, a) => { };
    //
    eventMap[EventTypes.Event1].Raise(this, new EventArgs());
