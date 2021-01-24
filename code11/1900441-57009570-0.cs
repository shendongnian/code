    // a queue for storing actions that shall be handled by the main thread
    // a ConcurrentQueue in specific is thread-save
    private ConcurrentQueue<Action> actions = new ConcurrentQueue<Action>();
    private void Update()
    {
        // invoke all actions from the threads in the main thread
        while(!actions.IsEmpty)
        {
            // TryDequeue writes the first entry to currentAction
            // and at the same time removes it from the queue
            // if it was successfull invoke the action otherwise do nothing
            if(actions.TryDequeue(out var currentAction))
            {
                currentAction?.Invoke();
            } 
        }
        if(removeTooltip)
        {
             hideTooltip();
        }
        
        if(showTooltip)
        {
             Debug.Log("Calling create tooltip");
             createTooltip();
        }
    }
    
