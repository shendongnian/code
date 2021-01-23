    protected override void OnStartup(StartupEventArgs e)
    {
      Application.Current.DispatcherUnhandledException +=
        new DispatcherUnhandledExceptionEventHandler(DispatcherUnhandledExceptionHandler);
      base.OnStartup(e);
    }
    void DispatcherUnhandledExceptionHandler(object sender, DispatcherUnhandledExceptionEventArgs args)
    {
      args.Handled = true;
      // implement recovery
      // execution will now continue...
    }
