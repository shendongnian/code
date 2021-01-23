            NLog.Logger logger = NLog.LogManager.GetLogger(context.Name);
            LogLevel logLevel = LogLevel.Info; // Default level to info
            switch (messageType)
            {
                case LogType.Debug:
                    logLevel = LogLevel.Debug;
                    break;
                case LogType.Info:
                    logLevel = LogLevel.Info;
                    break;
                case LogType.Warning:
                    logLevel = LogLevel.Warn;
                    break;
                case LogType.Error:
                    logLevel = LogLevel.Error;
                    break;
                case LogType.Fatal:
                    logLevel = LogLevel.Fatal;
                    break;
                default:
                    throw new ArgumentException("Log message type is not supported");                    
            }
            //
            // Build LogEvent here...
            //
            LogEventInfo logEvent = new LogEventInfo(logLevel, context.Name, message);
            logEvent.Exception = exception;
            //
            // Pass the type of your wrapper class here...
            //
            logger.Log(typeof(YourWrapperClass), logEvent);
        }
