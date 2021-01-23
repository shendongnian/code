    protected override void OnStartup(StartupEventArgs e)
        {
            App.Current.ShutdownMode = ShutdownMode.OnExplicitShutdown;
            App.HasRaisedFatalException = false;
            base.OnStartup(e);
            try
            {
                //Force just one copy to run
                this.ForceSingleInstance();
    ...
    ...
    ...
    }
