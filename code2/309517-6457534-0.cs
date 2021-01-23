    volatile int running;  //not a boolean to allow ProcessQueue to be reentrant.
    private void ProcessQueue(object unused)
    {
        do
        {
            ++running;
            Action current;
            while (pendingActions.TryDequeue(out current))
                current();
            --running;
        }
        while (pendingActions.Count != 0);
    } 
    public void BeginInvoke(Action method) 
    {     
        pendingActions.Enqueue(method);
        if (running != 0)
            uiContext.Post(ProcessQueue, null); 
    } 
