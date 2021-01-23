    if (VerboseLogging && !LogManager.Configuration.LoggingRules.Contains(VerboseLoggingRule))
    {
        LogManager.Configuration.LoggingRules.Add(VerboseLoggingRule);
        LogManager.ReconfigExistingLoggers();
    }
    else if (!VerboseLogging && LogManager.Configuration.LoggingRules.Contains(VerboseLoggingRule))
    {
        LogManager.Configuration.LoggingRules.Remove(VerboseLoggingRule);
        LogManager.ReconfigExistingLoggers();
    }
