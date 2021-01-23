    ThreadStart start = delegate()
    {
        // ...
    
        // This will work as its using the dispatcher
        DispatcherOperation op = Dispatcher.BeginInvoke(
            DispatcherPriority.Normal, 
            new Action<string>(SetStatus), 
            "From Other Thread (Async)");
        
        DispatcherOperationStatus status = op.Status;
        while (status != DispatcherOperationStatus.Completed)
        {
            status = op.Wait(TimeSpan.FromMilliseconds(1000));
            if (status == DispatcherOperationStatus.Aborted)
            {
                // Alert Someone
            }
        }
    };
    
    // Create the thread and kick it started!
    new Thread(start).Start();
