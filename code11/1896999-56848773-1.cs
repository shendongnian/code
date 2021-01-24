    public static async System.Threading.Tasks.Task RunAsync([TimerTrigger("0 */1 * * * *")]TimerInfo myTimer, ILogger log)
    {
        var ftpUserName = "xxxxxx";
        var ftpPassword = "xxxxxxxxx";
        var filename = "test.png";
        string blobConnectionString = "xxxxxxx";
        CloudStorageAccount storageAccount = CloudStorageAccount.Parse(blobConnectionString);
        CloudBlobClient blobClient = storageAccount.CreateCloudBlobClient();
        CloudBlobContainer container = blobClient.GetContainerReference("myblobcontainer");
        FtpWebRequest fileRequest = (FtpWebRequest)WebRequest.Create("ftp://xxxxxx/" + filename);
        fileRequest.Method = WebRequestMethods.Ftp.DownloadFile;
        fileRequest.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
        FtpWebResponse fileResponse = (FtpWebResponse)fileRequest.GetResponse();
        Stream fileStream = fileResponse.GetResponseStream();
        CloudBlockBlob blockBlob = container.GetBlockBlobReference(filename);
        await blockBlob.UploadFromStreamAsync(fileStream);
        log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
    }
