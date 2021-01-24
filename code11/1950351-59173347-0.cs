    using Microsoft.Azure.Cosmos;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace cosmosDBSDKV3
    {
        class Program
        {
            static void Main(string[] args)
            {
                var dbName = "<db name>";
                var containerName = "<container name>";
                
                CosmosClient client = new CosmosClient("<cosmos db url>", "<key here>");
                Database database = client.GetDatabase(dbName);
                Container container = database.GetContainer(containerName);
    
                ItemFeed(container).GetAwaiter().GetResult();
    
    
                Console.ReadKey();
            }
    
            private static async Task ItemFeed(Container container)
            {
                FeedIterator<SeasonInformation> setIterator = container.GetItemQueryIterator<SeasonInformation>(
                    "SELECT * FROM c where c.brand = 'hm' and c.DocumentType = 'Seasons'",
                   requestOptions: new QueryRequestOptions()
                   {
                       PartitionKey = new PartitionKey("hm"),
                       MaxConcurrency = 1,
                       MaxItemCount = 1
                   });
    
                List<SeasonInformation> seasonInformations = new List<SeasonInformation>();
    
                // SQL
    
                while (setIterator.HasMoreResults)
                {
                    int count = 0;
                    foreach (SeasonInformation item in await setIterator.ReadNextAsync())
                    {
                        count++;
                        seasonInformations.Add(item);
                    }
                }
    
                foreach (SeasonInformation item in seasonInformations) {
                    Console.WriteLine(item.id);
                    Console.WriteLine(item.Brand);
                }
                
    
    
            }
    
            class SeasonInformation
            {
                public string id { get; set; }
                [JsonProperty("brand")]
                public string Brand { get; set; }
                public string IntegrationSource { get; set; }
                public string DocumentType { get; set; }
                public string UpdatedDate { get; set; }
                public string UpdatedDateUtc { get; set; }
                public string UpdatedBy { get; set; }
                public JObject OriginalData { get; set; }
            }
        }
    
    }
