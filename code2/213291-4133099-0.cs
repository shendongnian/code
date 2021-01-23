    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = Logger.GetLogger();
            logger.LogMessage("Hello");
        }
    }
    public interface ILogger
    {
        void LogMessage(string message);
    }
    public class Logger : ILogger
    {
        private static Logger instance;
        public static Logger GetLogger()
        {
            return instance ?? (instance = new Logger());
        }
        public void LogMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
