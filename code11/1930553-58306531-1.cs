`
using System;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Microsoft.WindowsAzure.Storage.Blob;
namespace SampleFunctions
{
    public static class UnzipBlob
    {
        /// <summary>
        /// This function is triggered by new blobs (should be a ZIP file) 
        /// and extracts the contents of the zip as new, individual blobs to a storage account
        /// </summary>
        /// <param name="inputBlob"></param>
        /// <param name="inputBlobName"></param>
        /// <param name="outputContainer"></param>
        /// <param name="log"></param>
        /// <returns></returns>
        [FunctionName("UnzipBlob")]
        public static async Task Run([BlobTrigger("input-zips/{inputBlobName}", Connection = "AzureWebJobsStorage")] Stream inputBlob, string inputBlobName,
            Binder binder,
            ILogger log)
        {
            log.LogInformation($"Blob trigger function received blob\n Name:{inputBlobName} \n Size: {inputBlob.Length} Bytes");
            if (Path.GetExtension(inputBlobName)?.ToLower() == ".zip")
            {
                // We use the first char of the input file name as a dynamic part in the container. (Note: You should check if this is a valid char for the container name)
                var container = $"my-dynamic-container-{inputBlobName.Substring(0,1).ToLower()}";
                var attributes = new Attribute[]
                {
                        new BlobAttribute($"{container}", FileAccess.ReadWrite),
                        new StorageAccountAttribute("AzureWebJobsStorage")
                };
                var outputContainer = await binder.BindAsync<CloudBlobContainer>(attributes);
                await outputContainer.CreateIfNotExistsAsync();
                var archive = new ZipArchive(inputBlob);
                foreach (var entry in archive.Entries)
                {
                    // we write the output files to a directory with the same name as the input blob. Change as required
                    var blockBlob = outputContainer.GetBlockBlobReference($"{inputBlobName}/{entry.FullName}");
                    using (var fileStream = entry.Open())
                    {
                        if (entry.Length > 0)
                        {
                            log.LogInformation($"Extracting - {entry.FullName} to - {blockBlob.Name}");
                            await blockBlob.UploadFromStreamAsync(fileStream);
                        }
                    }
                }
            }
            else
            {
                log.LogInformation("Not a zip file. Ignoring");
            }
        }
    }
}
`
