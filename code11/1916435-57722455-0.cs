    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Microsoft.Azure.WebJobs;
    using Microsoft.Azure.WebJobs.Extensions.Http;
    using Microsoft.Azure.WebJobs.Host;
    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Blob;
    
    namespace DownloadFileV1
    {
        public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task<HttpResponseMessage> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
            {
                var storageAccount = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=bowmanimagestorage02;AccountKey=xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx;EndpointSuffix=core.windows.net");
                var myClient = storageAccount.CreateCloudBlobClient();
                var container = myClient.GetContainerReference("images");
                container.CreateIfNotExists(BlobContainerPublicAccessType.Blob);
                var blockBlob = container.GetBlockBlobReference("grass.jpg");
                using (var fileStream = System.IO.File.OpenWrite(@"C:\Users\bowmanzh\Downloads\download1.jpg"))
                {
                    blockBlob.DownloadToStream(fileStream);
                }
                return req.CreateResponse(HttpStatusCode.BadRequest, "");
            }
        }
    }
