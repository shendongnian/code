    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;
    using Microsoft.WindowsAzure.Storage.Table;
    
    namespace FunctionApp18
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static void Run([QueueTrigger("myqueue-items", Connection = "AzureWebJobsStorage")]string myQueueItem, 
                [Table("test1")]ICollector<Test> outTable,
                ILogger log)
            {
                log.LogInformation($"C# Queue trigger function processed: {myQueueItem}");
                outTable.Add(new Test() {
                    PartitionKey = "mypartition_key",
                    RowKey = Guid.NewGuid().ToString(),
                    QuoteText = myQueueItem
                });
            }
        }
    
        //define the table entity
        public class Test : TableEntity
        {
            public string QuoteText { get; set; }
        }   
        
    }
