    // in the bootstrapper    
    protected override void InitializeShell()
    {
        Container.Resolve<IWindowManager>().SwitchToLoginWindow();
    }
    // from the login window
    private void OnCredentialsValidated()
    {
        _windowManager.SwitchToShell();
    }
    // somewhere else
    private void OnLogOut()
    {
        _windowManager.SwitchToLoginWindow();
    }
