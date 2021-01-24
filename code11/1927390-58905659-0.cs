	private Task<string> ReturnString()
    {
        // throw new OperationCanceledException(_cancellationToken);   // This puts task in faulted, not canceled
        Task.Delay(5000, _cancellationToken).Wait(_cancellationToken); // Simulate work (with IO-bound call)
        // throw new OperationCanceledException(_cancellationToken);   // This puts task in faulted, not canceled
        // _cancellationToken.ThrowIfCancellationRequested();          // This puts task in faulted, not canceled  
        // throw new Exception("Throwing this exception works!");      // This works as expected (faulted)
        return Task.FromResult("Ready");
    }
    // ...
    Task<string> task = Task.Run(() => ReturnString()); // Canceled status gets propagated
