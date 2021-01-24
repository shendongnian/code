    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.Extensions.Logging;
    using Microsoft.Azure.Storage;
    using Microsoft.Azure.Storage.Blob;
    using System.Threading.Tasks;
    using System.Linq;
    
    namespace process
    {
        public static class process_file
        {
            [FunctionName("process_file")]
            public static async Task RunOrchestrator(
                [OrchestrationTrigger] DurableOrchestrationContext context)
            {
                var parallelTasks = new List<Task<int>>();
                IEnumerable<IListBlobItem> blobs = new IListBlobItem[0];
                // Replace "hello" with the name of your Durable Activity Function.
                blobs = await context.CallActivityAsync< IEnumerable<IListBlobItem> > ("process_file_GetBlobList", null);
               
                foreach (IListBlobItem blob in blobs)
                {
                    Task<int> task = context.CallActivityAsync<int>("process_file_ProcessBlob", blob);
                    //parallelTasks.Add(task);
                }
                //// Task<int> task= context.CallActivityAsync<string>("process_file_ProcessBlob", blobs);
    
    
            }
    
            [FunctionName("process_file_GetBlobList")]
            public static IEnumerable<IListBlobItem> GetBlobList([ActivityTrigger] string name, ILogger log)
            {
                string storageConnectionString = @"myconn";
                CloudStorageAccount storageAccount = CloudStorageAccount.Parse(storageConnectionString);
                CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("container");
                IEnumerable<IListBlobItem> blobs = new IListBlobItem[0];
    
                foreach (IListBlobItem blobItem in container.ListBlobs())
                {
    
                    if (blobItem is CloudBlobDirectory)
                    {
                        //Console.WriteLine(blobItem.Uri);
                        CloudBlobDirectory directory = (CloudBlobDirectory)blobItem;
                        blobs = directory.ListBlobs(true);
    
                    }
                }
    
                return blobs;
    
            }
            //IListBlobItem
            [FunctionName("process_file_ProcessBlob")]
            public static void ProcessBlob([ActivityTrigger]  IListBlobItem blob, ILogger log)
            {
                
                log.LogInformation("Simomn");
                //log.LogInformation(blobs.ToString());
                //var tasks = blobs.Select(currentblob => $"{currentblob.Uri.ToString()}");
            }
            [FunctionName("process_file_HttpStart")]
            public static async Task<HttpResponseMessage> HttpStart(
                [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")]HttpRequestMessage req,
                [OrchestrationClient]DurableOrchestrationClient starter,
                ILogger log)
            {
                // Function input comes from the request content.
                string instanceId = await starter.StartNewAsync("process_file", null);
    
                log.LogInformation($"Started orchestration with ID = '{instanceId}'.");
    
                return starter.CreateCheckStatusResponse(req, instanceId);
            }
        }
    }
