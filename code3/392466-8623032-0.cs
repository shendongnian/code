    public static class MyLogger
    {
        private static List<string> log = new List<string>();
        public static event EventHandler LogAdded;
        public static void Log(string message)
        {
            log.Add(message);
            if (LogAdded != null)
                LogAdded(null, EventArgs.Empty);
        }
        public static string GetLastLog()
        {
            if (log.Count > 0)
                return log[log.Count - 1];
            else
                return null;
        }
    }
