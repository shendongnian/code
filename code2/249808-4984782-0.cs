    public void Execute()
    {
        foreach (var action in _actions)
        {
            if (_abortingToken.WaitOne(0))
                break; // Execution aborted.
    
            var workThread = new Thread(action.Execute); 
            workThread.Start();
    
            while (!workThread.Join(100)) /Milliseconds, there is also a timespan overload
            {
                if (_abortingToken.WaitOne(1))
                    action.Abort();
            }
        }
    }
