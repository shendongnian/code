    public class LogEventArgs : EventArgs
    {
		public string LogText { get; }
		
		public LogEventArgs(string logText)
		{
			LogText = logText;
		}
    }
