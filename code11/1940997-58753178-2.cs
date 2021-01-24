    public async void DoWork()
    {
        await DoHeaviWorkAsync();
        Device.BeginInvokeOnMainThread(() =>
        {
            // Make changes to UI
        });
    }
