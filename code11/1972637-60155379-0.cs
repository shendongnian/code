    private async void OnSomeEvent(..)
    {
        pbStatus.IsIndeterminate = true;  // maybe show it
        var result = await GetAll();
        pbStatus.IsIndeterminate = false; // Maybe hide it
        // TODO: Do something with result
    }
    
    
    private async Task<Results> GetAll()
    {
        // some code
    }
