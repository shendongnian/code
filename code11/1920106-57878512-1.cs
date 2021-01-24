    public static class Program
    {
        public static void Main()
        { 
            LogConfiguration();
        }
        private static void LogConfiguration()
        {
           var config = new LoggingConfiguration()
        
           // Targets where to log to: File and Console
           var f1 = new FileTarget("file1") { FileName = "file1.txt" };
           var f2 = new FileTarget("file2") { FileName = "file2.txt" };
                    
           // Rules for mapping loggers to targets            
           config.AddRule(LogLevel.Info, LogLevel.Fatal, f1);
           config.AddRule(LogLevel.Debug, LogLevel.Fatal, f2);
                    
           // Apply config           
           NLog.LogManager.Configuration = config;
        }
    }
