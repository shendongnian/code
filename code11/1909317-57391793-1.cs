    public static class DebugListener
    {
        public static List<LogEntry> logs = new List<LogEntry>();
    
        [RuntimeInitializeOnLoadMethod]
        private static void InitializeOnLoad()
        {
            // removing the callback first makes sure it is only added once
            Application.logMessageReceived -= HandleLog;
            Application.logMessageReceived += HandleLog;
        }
    
        private static void HandleLog(string logString, string stackTrace, LogType type)
        {
            logs.Add(new LogEntry(logString, stackTrace, type));
        }
    }
    [Serializable]
    public class LogEntry
    {
        public string Message;
        public string StackTrace;
        public LogType Type;
    
        // default constructor is required for serialization
        public LogEntry() { }
    
        public LogEntry(string message, string stackTrace, LogType type)
        {
            Message = message;
            StackTrace = stackTrace;
            Type = type;
        }
    }
