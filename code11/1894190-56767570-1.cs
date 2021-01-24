            public static void ProcessQueueMessage([QueueTrigger("myqueue1", Connection = "AzureWebJobsStorage")]CloudQueueMessage message, ILogger log)
            {
                log.LogInformation("hello, can you see me?");
                log.LogInformation("Log test message:" + DateTime.Now.ToLongDateString());
                log.LogInformation("the queue message is: " + message.AsString);
            }
