    [FunctionName("HttpTriggerCSharp")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
    
            var ftpHost = "xxxxx";
            var ftpUserName = "xxxx";
            var ftpPassword = "xxxx";
            var filename = "xxxxx";            
            string blobConnectionString = "xxxxxxxxxxx";
            
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(blobConnectionString);
            CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("xxxxx");
            
           
            FtpClient client = new FtpClient(ftpHost, ftpUserName, ftpPassword); // or set Host & Credentials
            client.EncryptionMode = FtpEncryptionMode.Implicit;
            client.SslProtocols = SslProtocols.None;
            client.ValidateCertificate += new FtpSslValidation(OnValidateCertificate);
            client.Connect();
            
            void OnValidateCertificate(FtpClient control, FtpSslValidationEventArgs e) {
                // add logic to test if certificate is valid here
                e.Accept = true;
            }
            
            CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);
            var outStream = blockBlob.OpenWrite();
            client.Download(outStream,filename);
            outStream.Commit(); // I'm not sure if this is needed?
            
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    
            
            return  (ActionResult)new OkObjectResult($"Action succeeded.");
        }
