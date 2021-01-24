    public AppViewModel(MyClient client)
    {
        Client = client;
        Client.StatusStream().ObserveOnDispatcher().ToPropertyEx(this, x => x.Status);
    }
