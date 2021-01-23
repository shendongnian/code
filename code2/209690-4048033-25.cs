    static void CalculateAndProcessAsyncTask(object args)
    {
        // create a task
        Task<object> task = new Task<object>(DoSomeBlockingOperation, args);
        // define the callback when the call completes so we can process afterwards
        task.ContinueWith(t =>
            {
                // let's process!
                ProcessTheResult(t.Result);
            });
        // let's calculate! (asynchronously)
        task.Start();
    }
