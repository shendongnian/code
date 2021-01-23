    private AutoResetEvent waitHandle = new AutoResetEvent(false);
    
    void Loop()
    {
        while(true)
        {
            /*
            fetch and update stuff goes in here...
            */
    
            if (waitHandle.WaitOne(5000))
            {
                break;
            }
        }
    }
    
    public void Cancel()
    {
        waitHandle.Set();
    }
