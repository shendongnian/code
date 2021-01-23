    public static class LogManager
    {
        public static readonly ILogger Log = CreateLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
    
        /// <summary>
        /// Creates the logger for the specified type.
        /// </summary>
        /// <param name="loggerType">Type of the logger.</param>
        /// <returns></returns>
        public static Logger CreateLogger(Type loggerType)
        {
            return new Logger(loggerType);
        }
    
        /// <summary>
        /// Creates the logger for the specified name.
        /// </summary>
        /// <param name="loggerName">Name of the logger.</param>
        /// <returns></returns>
        public static Logger CreateLogger(string loggerName)
        {
            return new Logger(loggerName);
        }
    }
