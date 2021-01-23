    List<ILogger> loggers = new List<ILogger>();
    loggers.Add(new ConsoleLogger());
    var projectCollection = new ProjectCollection();
    projectCollection.RegisterLoggers(loggers);
    var project = projectCollection.LoadProject(buildFileUri); // Needs a reference to System.Xml
    try
    {
        project.Build();
    }
    finally
    {
        projectCollection.UnregisterAllLoggers();
    }
