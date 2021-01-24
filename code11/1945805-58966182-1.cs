[{
        "id": "1",
        "name": "test1",
        "age": "20"
    }, {
        "id": "2",
        "name": "test2",
        "age": "21"
    }, {
        "id": "3",
        "name": "test3",
        "age": "22"
    }, {
        "id": "4",
        "name": "test4",
        "age": "23"
    },
    {
        "id": "5",
        "name": "test5",
        "age": "24"
    }, {
        "id": "6",
        "name": "test6",
        "age": "25"
    }, {
        "id": "7",
        "name": "test7",
        "age": "26"
    }, {
        "id": "8",
        "name": "test8",
        "age": "27"
    }
]
My code
 private const string EndpointUrl = "";
        private const string AuthorizationKey = "";
        private const string DatabaseName = "testbulk";
        private const string ContainerName = "items";
        async static Task Main(string[] args)
        {
            string json = File.ReadAllText(@"E:\test.json");
            
            List<Item> lists = JsonConvert.DeserializeObject<List<Item>>(json);
            CosmosClientOptions options = new CosmosClientOptions() { AllowBulkExecution = true };
            CosmosClient cosmosClient = new CosmosClient(EndpointUrl, AuthorizationKey,options);
            
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            Console.WriteLine(database.Id);
            Container container = await database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
            Console.WriteLine(container.Id);
            
            List<Task> tasks = new List<Task>();
            foreach (Item item in lists)
            {
                tasks.Add(container.CreateItemAsync(item, new PartitionKey(item.Id))
                    .ContinueWith((Task<ItemResponse<Item>> task) =>
                    {
                        Console.WriteLine("Status: " + task.Result.StatusCode + "    Resource: "+ task.Result.Resource.Id );
                    }));
            }
            await Task.WhenAll(tasks);
}
class Item {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        [JsonProperty(PropertyName = "age")]
        public string Age { get; set; }
    }
[![enter image description here][2]][2]
For more details about how to develop your application, please refer to the [blog][3]
----------
##Update
I run my code in .Net 4.6.1 console application.
My code
 class Program
    {
        private const string EndpointUrl = "";
        private const string AuthorizationKey = "";
        private const string DatabaseName = "testbulk";
        private const string ContainerName = "items";
        async static Task Main(string[] args)
        {
            string json = File.ReadAllText(@"E:\test.json");
            List<Item> lists = JsonConvert.DeserializeObject<List<Item>>(json);
            CosmosClientOptions options = new CosmosClientOptions() { AllowBulkExecution = true };
            CosmosClient cosmosClient = new CosmosClient(EndpointUrl, AuthorizationKey, options);
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            Console.WriteLine(database.Id);
            Container container = await database.CreateContainerIfNotExistsAsync(ContainerName, "/id");
            Console.WriteLine(container.Id);
            List<Task> tasks = new List<Task>();
            foreach (Item item in lists)
            {
                tasks.Add(container.CreateItemAsync(item, new PartitionKey(item.Id))
                    .ContinueWith((Task<ItemResponse<Item>> task) =>
                    {
                        Console.WriteLine("Status: " + task.Result.StatusCode + "    Resource: " + task.Result.Resource.Id);
                    }));
            }
            await Task.WhenAll(tasks);
            Console.ReadLine();
        }
        class Item
        {
            [JsonProperty(PropertyName = "id")]
            public string Id { get; set; }
            [JsonProperty(PropertyName = "name")]
            public string Name { get; set; }
            [JsonProperty(PropertyName = "age")]
            public string Age { get; set; }
        }
    }
