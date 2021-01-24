    public class MyItem : TableEntity
    {
    }
    
    public static async Task<IActionResult> Run(
    	[HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequestMessage req,
    	[Table("AzureWebJobsHostLogsCommon")] CloudTable cloudTable,
    	ILogger log)
    {
    	log.LogInformation("C# HTTP trigger function processed a request.");
    
    	string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
        MyItem myItem = JsonConvert.DeserializeObject<MyItem>(requestBody);
    
    	// query the table - here I have used the partition key but you could replace "PartitionKey" with any column in your table
    	TableQuery<MyItem> query = new TableQuery<MyItem>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, myItem.PartitionKey));
    	IEnumerable<MyItem> entities = await cloudTable.ExecuteQuerySegmentedAsync(query, null);
    
    	// if all items have a unique partition key and the item exists 
    	// you should only get one item returned, if not it will be null (default)
    	MyItem existingMyItem = entities.FirstOrDefault();
    
        // if the item is null, you want to insert it into the table
    	if (existingMyItem == null)
    	{
    		// create an InsertOperation for your new item
    		TableOperation insertOperation = TableOperation.Insert(myItem);
    		await cloudTable.ExecuteAsync(insertOperation);
    	}
    
    	return new OkObjectResult("");
    }
