            public static void getLog(string className, string message)
            {
                log4net.ILog iLOG = LogManager.GetLogger(className);
                iLOG.Error(message);    // Info, Fatal, Warn, Debug
            }
