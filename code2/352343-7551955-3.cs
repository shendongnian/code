    private Object condition_lock = new Object();
    private bool handlingEvent = false;
    public void MyEventHandler(object sender, EventArgs e)
    {
        lock (condition_lock)
        {
            if (handlingEvent) return;
            handlingEvent = true;
        }
        try
        {
            // do some stuff here
        }
        finally
        {
            handlingEvent = false;
        }
    }
