    #r "Microsoft.WindowsAzure.Storage"
    using System;
    using Microsoft.WindowsAzure.Storage.Blob;
    using Microsoft.Extensions.Logging;
    public static void Run(Stream myBlob, CloudBlobContainer container,ILogger log)
    {
    log.LogInformation($"Container name: {container.Name}");
    var blob= container.GetBlockBlobReference("Bill.pdf");
    log.LogInformation($"Blob size: {blob.StreamWriteSizeInBytes}");
    log.LogInformation($"C# Blob trigger function processed {myBlob}");
    }
