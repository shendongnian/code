    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    
    namespace WebJob1template
    {
        public class Functions
        {        
            public static void ProcessQueueMessage([QueueTrigger("queue")] string message, ILogger log)
            {
                //log.WriteLine(message);
                log.LogInformation(message);
            }
        }
    }
