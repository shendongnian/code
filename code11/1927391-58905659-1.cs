    private async Task<string> ReturnString()
    {
        // throw new OperationCanceledException(_cancellationToken);   // This puts task in faulted, not canceled
        await Task.Delay(5000, _cancellationToken); // Simulate work (with IO-bound call)
        // throw new OperationCanceledException(_cancellationToken);   // This puts task in faulted, not canceled
        // _cancellationToken.ThrowIfCancellationRequested();          // This puts task in faulted, not canceled  
        // throw new Exception("Throwing this exception works!");      // This works as expected (faulted)
        return "Ready";
    }
