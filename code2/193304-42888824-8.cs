    ICommand _exitCommand;
    public ICommand ExitCommand
    {
        get
        {
            if (_exitCommand == null)
                _exitCommand = new RelayCommand<object>(call => OnExit());
            return _exitCommand;
        }
    }
    void OnExit()
    {
         var msg = new NotificationMessageAction<object>(this, "ExitApplication", (o) =>{});
         Messenger.Default.Send(msg);
    }
