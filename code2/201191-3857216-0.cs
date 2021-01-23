    protected void OnMyEvent(EventArgs e)
    {
        // Note the copy to a local variable, so that we don't risk a
        // NullReferenceException if another thread unsubscribes between the test and
        // the invocation.
        EventHandler handler = MyEvent;
        if (handler != null)
        {
            handler(this, e);
        }
    }
