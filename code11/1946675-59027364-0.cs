 [{
         "SId": "101",
         "SName": "ABC"
     }, {
         "SId": "102",
         "SName": "XYZ"
     }
 ]
 My code
        async static Task Main(string[] args)
        {
            string json = File.ReadAllText(@"E:\test.json");
            List<StudentInfo> lists = JsonConvert.DeserializeObject<List<StudentInfo>>(json);            
            CosmosClientOptions options = new CosmosClientOptions() { AllowBulkExecution = true, ConnectionMode = ConnectionMode.Gateway };
            CosmosClient cosmosClient = new CosmosClient(EndpointUrl, AuthorizationKey, options);
            Database database = await cosmosClient.CreateDatabaseIfNotExistsAsync(DatabaseName);
            Console.WriteLine(database.Id);
            Container container = await database.CreateContainerIfNotExistsAsync(ContainerName,"/SId");
            Console.WriteLine(container.Id);
            List<Task> tasks = new List<Task>();
            foreach (StudentInfo item in lists)
            {
                item.Id = Guid.NewGuid().ToString();// add the line in your code
                tasks.Add(container.CreateItemAsync(item, new PartitionKey(item.SId))
                    .ContinueWith((Task<ItemResponse<StudentInfo>> task) =>
                    {
                        Console.WriteLine("Status: " + task.Result.StatusCode + "    Resource: " + task.Result.Resource.SId);
                    }));
            }
            await Task.WhenAll(tasks);
            Console.ReadLine();
        }
        class StudentInfo
        {            
            public string SId { get; set; }
            public string SName { get; set; }
            [JsonProperty(PropertyName = "id")]// add the code in your custom object
            public string Id { get; set; }//add the code in your custom object
           
        }
    }
[![enter image description here][2]][2]
  [1]: https://docs.microsoft.com/en-us/azure/cosmos-db/databases-containers-items#properties-of-an-item
  [2]: https://i.stack.imgur.com/tZkdy.png
