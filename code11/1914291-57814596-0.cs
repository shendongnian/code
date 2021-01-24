    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using System.IO;
    
    namespace ConsoleApp1
    {
        public class Functions
        {
            public static void ProcessQueueMessage(
                [BlobTrigger("images/{name}")]Stream myBlob, 
                [Blob("form/{name}", FileAccess.Write)] Stream imageSmall, 
                string name, 
                ILogger log
                )
            {
                log.LogInformation("webjobs blob trigger works!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            }
        }
    }
