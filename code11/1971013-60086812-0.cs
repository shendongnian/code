    using Microsoft.Azure.WebJobs;
    using Microsoft.Extensions.Logging;
    using Microsoft.WindowsAzure.Storage.Blob;
    
    namespace FunctionApp3
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static void Run([BlobTrigger("container-name/folder-name/{name}", Connection = "AzureWebJobsStorage")]ICloudBlob myBlob, string name, ILogger log)
            {
                log.LogInformation("...change blob property...");
                //specify the property here
                myBlob.Properties.ContentType = "text/html";
    
                //commit the property
                myBlob.SetPropertiesAsync();
            }
        }
    }
