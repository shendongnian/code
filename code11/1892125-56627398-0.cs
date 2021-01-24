    public class Program
    {
        [NoAutomaticTrigger]
        public static void CreateQueueMessage(ILogger logger, string value, [Queue("myqueue")] out string message)
        {
            ...
        }
        public static void Main(string[] args)
        {
            ...
            ...
        }
    }
