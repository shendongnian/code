    public void Raise(String eventName, object source, EventArgs eventArgs)
    {
        var field = this.GetType().GetField(eventName, BindingFlags.Instance | BindingFlags.NonPublic);
        if (field == null)
            throw new ArgumentException("No such event: " + eventName);
    
        var eventDelegate = (MulticastDelegate)field.GetValue(this);
        if (eventDelegate != null)
            foreach (var handler in eventDelegate.GetInvocationList())
                handler.Method.Invoke(handler.Target, new object[] { source, eventArgs });                
    }
