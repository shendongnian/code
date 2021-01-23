    public static class Logger
    {
        static readonly object _locker = new object();
        public static void Log(string logMessage)
        {
            try
            {
                var logFilePath = Path.Combine(@"C:\YourLogDirectoryHere", "Log.txt");
                //Use this for daily log files : "Log" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                WriteToLog(logMessage, logFilePath);
            }
            catch (Exception e)
            {
                //log log-exception somewhere else if required!
            }
        }
        static void WriteToLog(string logMessage, string logFilePath)
        {
            lock (_locker)
            {
                File.AppendAllText(logFilePath,
                        string.Format("Logged on: {1} at: {2}{0}Message: {3}{0}--------------------{0}", 
                        Environment.NewLine, DateTime.Now.ToLongDateString(),
                        DateTime.Now.ToLongTimeString(), logMessage));
            }
        }
    }
