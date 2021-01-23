    LogEntry logEntry = new LogEntry();
    logEntry.Priority = 2;
    logEntry.Categories.Add("Trace");
    logEntry.Categories.Add("UI Events");
    
    if (Logger.ShouldLog(logEntry))
    {
      // Perform operations (possibly expensive) to gather additional information 
      // for the event to be logged. 
    }
    else
    {
      // Event will not be logged. Your application can avoid the performance
      // penalty of collecting information for an event that will not be
      // logged.
    }
