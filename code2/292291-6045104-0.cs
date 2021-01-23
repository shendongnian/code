    public event EventHandler MyEvent;
    
    protected virtual void OnMyEvent()
    {
        EventHandler handler = MyEvent; // keep a copy to avoid race conditions
        if (handler != null)
            handler(this, EventArgs.Empty);
    }
