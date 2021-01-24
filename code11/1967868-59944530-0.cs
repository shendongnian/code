            static void Main(string[] args)
            {
                //use stop watch to calculate the uploading time.
                Stopwatch stopwatch = Stopwatch.StartNew(); 
    
                string storageConnectionString = "DefaultEndpointsProtocol=https;AccountName=xxx;AccountKey=xxxx;EndpointSuffix=core.windows.net";
                CloudStorageAccount account = CloudStorageAccount.Parse(storageConnectionString);
    
                CloudBlobClient blobClient = account.CreateCloudBlobClient();
                CloudBlobContainer blobContainer = blobClient.GetContainerReference("test2");
                blobContainer.CreateIfNotExists();
    
                // the file being uploaded is about 63MB in size
                string source_path = @"F:\temp\postman.zip";
    
                CloudBlockBlob destBlob = blobContainer.GetBlockBlobReference("myblob111.zip");
    
                TransferManager.Configurations.ParallelOperations = 5;
                // Setup the transfer context and track the upload progress
                SingleTransferContext context = new SingleTransferContext();
                context.ProgressHandler = new Progress<TransferStatus>((progress) =>
                {
                    Console.WriteLine("Bytes uploaded: {0}", progress.BytesTransferred);
                });
                // Upload a local blob
                var task = TransferManager.UploadAsync(
                    source_path, destBlob, null, context, CancellationToken.None);
                task.Wait();
    
                stopwatch.Stop();
                Console.WriteLine($"it takes about {stopwatch.ElapsedMilliseconds} milliSeconds");
    
                Console.WriteLine("the upload is completed");
                Console.ReadLine();
           }
