    private bool _isDebugMode = false;
    public bool IsDebugMode
    {
        get
        {
            CheckDebugMode();
            return _isDebugMode;
        }
    }
    [Conditional("DEBUG")]
    private void CheckDebugMode()
    {
        _isDebugMode = true;
    }
    private void DisplaySplashScreen()
    {
        if (IsDebugMode) return;
        var splashScreenViewModel = new SplashScreenVM(500)
        {
            Header = "MyCompany Deals",
            Title = "Main Menu Test",
            LoadingMessage = "Creating Repositories...",
            VersionString = string.Format("v{0}.{1}.{2}",
                GlobalInfo.Version_Major, GlobalInfo.Version_Minor, GlobalInfo.Version_Build)
        };
        SplashScreenFactory.CreateSplashScreen(splashScreenViewModel);
    }
