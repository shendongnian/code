    public void LogSomething(this ILog logger, string username, string message)
    {
      LogEventInfo myEvent = new LogEventInfo(LogLevel.Debug, "", message);
      myEvent.LoggerName = logger.Name;
      myEvent.Properties.Add("User", username);
      logger.Log(myEvent);
    }
