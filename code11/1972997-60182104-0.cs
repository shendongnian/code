    public static class Function1
        {
            [FunctionName("Function1")]
            public static async Task RunAsync(
                [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
                [Blob("test/test.txt",FileAccess.ReadWrite)]CloudBlockBlob blob1,
                [Blob("test/out.txt", FileAccess.ReadWrite)]CloudBlockBlob blob2,
                ILogger log)
            {
                log.LogInformation("C# HTTP trigger function processed a request.");
    
                string test = await blob1.DownloadTextAsync();
                string outtxt = await blob2.DownloadTextAsync();
                log.LogInformation("test value： " + test);
                log.LogInformation("outtxt value： " + outtxt);
    
            }
        }
