    var successful = false
    while (!successful){
    
        // Create cancellation token that gets cancelled when one of the tasks terminates.
        var cts = new CancellationTokenSource();
        _ = Task.Run(async () =>
        {
            await Task.WhenAny(
                taskCompletionSource1.Task,
                taskCompletionSource1.Task);
            cts.Cancel();
        });
        // Try to perform operation.
        Policy
            .Handle<RetryException>()
            .WaitAndRetryForever(
                TimeSpan.FromSeconds(10))
            .Execute(
                // Method TryToDoStuff will throw RetryException if it fails 
                ct => TryToDoStuff(), 
                // Pass in cancellation token.
                cts.Token);
    }
