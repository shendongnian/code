    private int _checkUsernameCalls = 0;
    public string Username
    {
        get => _username;
        set
        {
            SetProperty(ref _username, value);
            _checkUsernameCalls++;
            Task.Delay(TimeSpan.FromSeconds(1)).ContinueWith(t => CheckUsernameExists());
        }
    }
    void CheckUsernameExists()
    {
        if (--_checkUsernameCalls > 0)
        {
            return;
        }
        // actual checks...
    }
