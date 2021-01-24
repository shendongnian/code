    protected override void OnStartup(object sender, StartupEventArgs e)
    {
        Application.ShutdownMode = ShutdownMode.OnExplicitShutdown;
        var windowManager = IoC.Get<IWindowManager>();
        var eventAggregator = IoC.Get<IEventAggregator>();
        windowManager.ShowDialog(new AnimatedSplashViewModel(eventAggregator));
 	    DisplayRootViewFor(typeof(ShellViewModel));
    }
    ...
    private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
    	TryClose();
    }
