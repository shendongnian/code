public abstract Task<ItemResponse<T>> CreateItemAsync<T>(T item, PartitionKey? partitionKey = null, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
public abstract Task<ResponseMessage> CreateItemStreamAsync(Stream streamPayload, PartitionKey partitionKey, ItemRequestOptions requestOptions = null, CancellationToken cancellationToken = default(CancellationToken));
I find a workaround for your request, you can take advantage of `Newtonsoft.Json` package. 
Here is the quick sample I used to test:
	class Program
	{
		private static string EndpointUrl = "https://jackdemo.documents.azure.com:443/";
		private static string PrimaryKey = "AWgnKF********odqAkQwA==";
		private static CosmosClient cosmosClient;
		private static Database database;
		private static Container container;
		private static string databaseId = "db";
		private static string containerId = "demo";
		static void Main(string[] args)
		{
			cosmosClient = new CosmosClient(EndpointUrl, PrimaryKey);
			database = cosmosClient.CreateDatabaseIfNotExistsAsync(databaseId).Result;
			container = database.CreateContainerIfNotExistsAsync(containerId, "/key").Result;
			string json = "{\"id\":\"bbb\",\"key\":\"bbb\"}";
			var obj = JsonConvert.DeserializeObject(json);
			container.CreateItemAsync<Object>(obj).Wait();
            cosmosClient.Dispose();
			Console.ReadLine();
		}
	}
Result
------
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/3VweW.png
