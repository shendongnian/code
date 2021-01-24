    static public class LogDebugProxy
    {
        static public bool LogDebug = false;
        static public void debug(log4net.ILog log)
        {
            if (LogDebug)
                log.debug();
        }
    }
