    private void Foo()
    {
      var currentApplication = typeof(System.Windows.Application).GetProperty("Current");
      if (currentApplication != null)
      {
        var application = currentApplication.GetValue(this, null) as    System.Windows.Application;
        if (application != null)
        {
          application.DispatcherUnhandledException += this.DispatcherUnhandledException;
        }
      }
    }
    public void Bar(bool useAutoHandler)
    {
      if (useAutoHandler)
      {
        Foo();
      }
    }
