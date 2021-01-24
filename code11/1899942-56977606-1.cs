    public class FunctionExecution : TableEntity
    {
    	public string FunctionName { get; set; }
    }
    
    public static class HttpTriggeredFunction
    {
    	[FunctionName("HttpTriggeredFunction")]
    	public static async Task<IActionResult> Run(
    		[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
    		[Table("FunctionExecutions", Connection = "StorageConnectionString")] CloudTable table,
    		ExecutionContext executionContext,
    		ILogger log)
    	{
    		log.LogInformation("C# HTTP trigger function processed a request.");
    
    		// query table storage for all entries (you might want to restrict the query to the last day etc)
    		TableQuery<FunctionExecution> query = new TableQuery<FunctionExecution>();
    		TableQuerySegment<FunctionExecution> data = await table.ExecuteQuerySegmentedAsync(query, null);
    
    		// get the last function execution by ordering by Timestamp
    		FunctionExecution lastFunctionExecution = data.OrderByDescending(r => r.Timestamp).FirstOrDefault();
    
    		DateTimeOffset? begin = lastFunctionExecution?.Timestamp;
    		DateTime end = DateTime.UtcNow;
    
    		// call off to ThirdPartyClient
    
    		// log successful execution to table storage
    		TableOperation insertOperation = TableOperation.Insert(new FunctionExecution
    		{
    			PartitionKey = executionContext.InvocationId.ToString(), // using the InvocationId of the function so you can relate executions if needed
    			RowKey = Guid.NewGuid().ToString(), 
    			Timestamp = DateTimeOffset.UtcNow, // set the Timestamp to now as the function has been successful
    			FunctionName = "HttpTriggeredFunction" // optional but you might want to save the function name in your case FunctionNames.GetInvoicesAsync
    		});
    
    		await table.ExecuteAsync(insertOperation);
    
    		return new OkObjectResult(null);
    	}
    }
