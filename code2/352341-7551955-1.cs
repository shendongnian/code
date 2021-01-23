    public void MyEventHandler(object sender, EventArgs e)
    {
        if (!Monitor.TryEnter(locker)) return;
        try
        {
            // do some stuff here
        }
        finally
        {
            Monitor.Exit(locker);
        }
    }
