    private void UpdateTrackResponseWindow(AbstractResponse message) 
    {
        Task.Factory.StartNew(
           () => TrackResponseMessage.Add(FormatMessageResponseToString(message)),
           CancellationToken.None, TaskCreationOptions.None,
           uiScheduler); 
    }
