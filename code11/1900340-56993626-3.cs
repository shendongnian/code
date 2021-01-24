    public class ListLoggerDouble : ILogger
    {
        public List<Exception> Exceptions = new List<Exception>();
        public List<string> Messages = new List<string>();
        public void LogError(Exception ex)
        {
            Exceptions.Add(ex);
        }
        public void LogMessage(string message)
        {
            Messages.Add(message);
        }
    }
