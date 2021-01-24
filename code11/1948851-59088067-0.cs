    public class LoggingSettings
    {
        public bool includeScopes;
        public LogLevel logLevel;
        public int day;
    }
    
    var settings = new LoggingSettings
            {
                includeScopes = true,
                typeOrder = "asc",
                logLevel = new LogLevel
                {
                    microsoft = "Warning",
                    system = "Warning"
                }
            };
