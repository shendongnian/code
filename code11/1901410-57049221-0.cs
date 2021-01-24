    public static void ProcessQueueMessage([QueueTrigger("myqueue")] string message,ILogger logger, string id)
            {
                logger.LogInformation(message);
                logger.LogInformation($"{message}id={id}");
            }
