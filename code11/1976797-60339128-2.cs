    using System.IO;
    using Microsoft.Azure.WebJobs;
    using Microsoft.ServiceBus.Messaging;
    
    namespace WebJob1
    {
        public class Functions
        {
            
            [ServiceBusAccount("AzureWebJobsServiceBus")]
            public static void ProcessQueueMessage([ServiceBusTrigger(topicName:"testtopic",subscriptionName:"testsub", access: AccessRights.Manage)] string message, TextWriter log)
            {
                log.WriteLine(message);
            }
        }
    }
