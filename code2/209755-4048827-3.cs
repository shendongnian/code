    public void fireEvent(String eventName)
    {
        // Get a reference to the backing field
        var del = (Delegate)typeof(EventHub)
                    .GetField(eventName, BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(this);
         // Invoke the delegate, it's invocation-list will contain the listeners
         if(del != null)
            del.DynamicInvoke(this, EventArgs.Empty);
    }
