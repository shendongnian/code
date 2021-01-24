    protected override void OnStart()
    {
        NavigateToEntryAsync()
            .ContinueWith(
                t => Log.Error("Unhandled exception while navigation to entry page", t.Exception.InnerException), 
                TaskContinuationOptions.OnlyOnFaulted);
    }
    protected async Task NavigateToEntryAsync()
    {
        login = new List<Login>();
        List<Login> items = await App.dataManager.GetLoginAsync();
        if (items.Count <= 0)
        {
            Device.BeginInvokeOnMainThread(() => MainPage = (new Registration()));
        }
        else
        {
            Device.BeginInvokeOnMainThread(() => MainPage = (new LoginPage()));
        }
    }
