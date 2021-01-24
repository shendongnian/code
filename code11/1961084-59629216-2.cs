    public MyCustomControl()
    {
      Dispatcher.UnhandledException += Dispatcher_UnhandledException;
    }
    void Dispatcher_UnhandledException(object sender, System.Windows.Threading.DispatcherUnhandledExceptionEventArgs e)
    {
      switch (e.Exception)
      {
        case AnimationException aniEx:
          Log(aniEx.GetDetails());
          break;
        // ...
        // default: ...
      }
    }
