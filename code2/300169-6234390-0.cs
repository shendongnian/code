    public void RegisterHandler(string name)
    {
        // Attach to the event.
        EventInfo e = mappings[name];
        e.AddEventHandler(this, Delegate.CreateDelegate(e.EventHandlerType, this, this.GetType().GetMethod("EventHandler")));
    }
    public void EventHandler(object sender, AutoWrapEventArgs raw)
    {
        // Dispatch event to internal handler.
        func.Call(this, args.GetParameters());
    }
