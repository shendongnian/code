    public static void Debug(object message)
    {
      MethodBase mb = GetCallingMethod();
      Type t = mb.DeclaringType;
      LogEventInfo logEvent = new LogEventInfo(LogLevel.Debug, t.Name, null, "{0}", new object [] message, null);
      ILogger logger = getLogger(t) As ILogger;
      logger.Log(declaringType, logEvent)
    }
