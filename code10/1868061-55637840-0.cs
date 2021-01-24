class model : TableEntity{
    public string Name { get; set; }
    public override string ToString(){
     return  " " + Name;
    }
}
static async Task<TableResult>  GetAllMessages(CloudTable table, String InvocationName)
{
    TableResult x = await table.ExecuteAsync(TableOperation.Retrieve(InvocationName,"1" ));    
    return x;
}
public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route =null)] HttpRequest req,ILogger log)
{
    CloudStorageAccount storageAccount = CloudStorageAccount.Parse(connectionString);
    CloudTableClient tableClient = storageAccount.CreateCloudTableClient();
    CloudTable table = tableClient.GetTableReference("models");
    var x = await GetAllMessages(table, "InvocationName");
    string url = ((model)x.Result).ToString();
}
