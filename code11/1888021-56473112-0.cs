    public class MyPoco
    {
    	public string PartitionKey { get; set; }
    	public string RowKey { get; set; }
    	public string Text { get; set; }
    }
    
    [FunctionName("TableOutput")]
    [return: Table("MyTable")]
    public static MyPoco TableOutput(
    		[HttpTrigger] dynamic input, 
    		ILogger log)
    {
    	log.LogInformation($"C# http trigger function processed: {input.Text}");
    	return new MyPoco { PartitionKey = "Http", RowKey = Guid.NewGuid().ToString(), Text = input.Text };
    }
