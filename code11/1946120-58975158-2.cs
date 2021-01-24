    public class MyEntity : TableEntity
    {
    	public string Name { get; set; }
    }
    
    public static class HttpTriggeredFunction
    {
    	[FunctionName("HttpTriggeredFunction")]
    	public static async Task<IActionResult> Run(
    		[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
    		[Table("AzureFunctionsSandbox", Connection = "StorageConnectionString")] CloudTable cloudTable,
    		ILogger log)
    	{
    		log.LogInformation("C# HTTP trigger function processed a request.");
    
    		var myEntity = new MyEntity
    		{
    			PartitionKey = Guid.NewGuid().ToString(),
    			RowKey = Guid.NewGuid().ToString(),
    			Name = "chris"
    		};
    
    		TableOperation insert = TableOperation.InsertOrReplace(myEntity);
    
    		await cloudTable.ExecuteAsync(insert);
    
    		return new OkObjectResult(null);
    	}
    }
