	private Task<string> ReturnString()
    {
        Task.Delay(5000, _cancellationToken).Wait(_cancellationToken);
        return Task.FromResult("Ready");
    }
    // ...
    Task<string> task = Task.Run(() => ReturnString()); // Canceled status gets propagated
