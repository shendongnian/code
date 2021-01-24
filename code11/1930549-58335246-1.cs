	public static class Logger
	{
		private static List<ILogger> _loggers = new List<ILogger>();
		public static void Log(string message)
		{
			foreach (var logger in _loggers)
				logger.Write(message);
		}
		public static void AddLogger(ILogger logger)
		{
			_loggers.Add(logger);
		}
	}
	public interface ILogger
	{
		void Write(string message);
	}
	public class SpecialLogger : ILogger
	{
		public void Write(string message)
		{
			//special log code here eg
			Console.WriteLine(message);
		}
	}
