    public static class LogHelper
    {
        private static readonly object _syncRoot = new object();
        public static void AppendToLog(string appendString)
        {
            lock (_syncRoot)
            {
                File.AppendAllText("log.txt", appendString);
            }
        }
    }
