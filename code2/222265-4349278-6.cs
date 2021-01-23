    /// <summary>
    /// Delegate backing the SomeEvent event.
    /// </summary>
    SomeEventHandler someEvent;
    
    /// <summary>
    /// Lock for SomeEvent delegate access.
    /// </summary>
    readonly object someEventLock = new object();
    
    /// <summary>
    /// Description for the event
    /// </summary>
    public event SomeEventHandler SomeEvent
    {
        add
        {
            lock (someEventLock)
            {
                someEvent += value;
            }
        }
        remove
        {
            lock (someEventLock)
            {
                someEvent -= value;
            }
        }
    }
    
    /// <summary>
    /// Raises the SomeEvent event
    /// </summary>
    protected virtual OnSomeEvent(EventArgs e)
    {
        SomeEventHandler handler;
        lock (someEventLock)
        {
            handler = someEvent;
        }
        if (handler != null)
        {
            handler (this, e);
        }
    }
