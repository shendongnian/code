    AppDomain.CurrentDomain.UnhandledException += OnCurrentDomainUnhandledException;
    //Add these two lines if you are using winforms
    Application.ThreadException += OnApplicationThreadException;
    Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
    private void OnCurrentDomainUnhandledException(object sender, System.Threading.ThreadExceptionEventArgs e)
    {
        //Log error
        
        //RestartTheApplication
    }
