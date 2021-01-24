    public class Functions {
        public static void ProcessQueueMessage(
            [QueueTrigger("myqueue")] string message, 
            ILogger logger, 
            MyOptions options) {
            logger.LogInformation(message);
            logger.LogInformation(options.MyDatabase);
        }
    }
    
