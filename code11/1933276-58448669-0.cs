    private async void Login() 
    {
        BusyMessage = message;
        IsBusy = true;
        await Task.Delay( TimeSpan.FromSeconds( 10 ) );
        IsBusy = false;
    }
