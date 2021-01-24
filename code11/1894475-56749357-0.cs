    [FunctionName("HttpTriggeredFunction")]
    public static async Task<IActionResult> Run(
    	[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
    	[Blob("blobcontainer", Connection = "StorageConnectionString")] CloudBlobContainer outputContainer,
    	ILogger log)
    {
    	log.LogInformation("C# HTTP trigger function processed a request.");
    	
    	await outputContainer.CreateIfNotExistsAsync();
    
    	var body = await req.Content.ReadAsStringAsync();
    	var blobName = Guid.NewGuid().ToString();
    
    	var cloudBlockBlob = outputContainer.GetBlockBlobReference(blobName);
    	await cloudBlockBlob.UploadTextAsync(body);
    
    	return new OkObjectResult(blobName);
    }
