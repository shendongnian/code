    public void fireEvent(String eventName)
    {
        var del = (Delegate)typeof(EventHub)
                    .GetField(eventName, BindingFlags.NonPublic | BindingFlags.Instance)
                    .GetValue(this);
        if(del != null)
            del.DynamicInvoke(this, EventArgs.Empty);
    }
