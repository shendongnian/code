    public void RegisterHandler(string name)
    {
        EventInfo e = mappings[name];
        EventHandler<AutoWrapEventArgs> handler = (s, raw) =>
            {
                func.Call(this, raw.GetParameters());
            };
        e.AddEventHandler(this, Delegate.CreateDelegate(e.EventHandlerType, null, handler.Method));
    }
