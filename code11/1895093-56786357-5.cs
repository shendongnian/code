    private async Task TheTaskThatTakesAWhile()
    {
        // do whatever takes long here
    }
    
    // usually you should avoid having async void
    // but when including an Action as callback this is fine
    public async void StartBackgroundTask(Action onSuccess = null)
    {
        await TheTaskThatTakesAWhile();
    
        onSuccess?.Invoke();
    }
