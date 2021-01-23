    ServiceBase service = ...;
    if (Environment.UserInteractive)
    {
        // run as application
        Application.EnableVisualStyles();
        Application.Run(new SomeForm()); // the form should call OnStart on the service
    }
    else
    {
        // run as service
        ServiceBase.Run(service);
    }
