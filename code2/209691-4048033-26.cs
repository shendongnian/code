    // need to have an asynchronous version
    static async Task<object> DoSomeBlockingOperationAsync(object args)
    {
        //it is my understanding that async will take this method and convert it to a task automatically
        return DoSomeBlockingOperation(args);
    }
    static async void CalculateAndProcessAsyncNew(object args)
    {
        // let's calculate! (asynchronously)
        object result = await DoSomeBlockingOperationAsync(args);
        // let's process!
        ProcessTheResult(result);
    }
