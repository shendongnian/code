    class Program
    {
        public class Document  
        {
            public int Id { get; set; }
            public DateTime Timestamp { get; set; }
        } 
        
        static async Task Main(string[] args)
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var connectionSettings = new ConnectionSettings(pool);
            connectionSettings.DefaultIndex("documents");
            
            //only for debbuging purpose, don't use in production
            connectionSettings.DisableDirectStreaming();
            connectionSettings.PrettyJson();
            
            var client = new ElasticClient(connectionSettings);
            await client.Indices.DeleteAsync("documents");
            await client.Indices.CreateAsync("documents");
            var response = await client.IndexAsync(
                new Document {Id = 1, Timestamp = new DateTime(2010, 01, 01, 10, 0, 0)}, descriptor => descriptor);
            var searchResponse = await client.SearchAsync<Document>(s => s
                .Query(q => q
                    .Bool(b => b
                        //I'm using date range in filter context as I don't want elasticsearch
                        //to calculate score for each document found,
                        //should be faster and likely it will be cached
                        .Filter(f =>
                            f.DateRange(dt => dt
                                .Field(field => field.Timestamp)
                                .LessThanOrEquals(new DateTime(2010, 01, 01, 11, 0, 0))
                                .TimeZone("+1:00"))))));
            
            //prints 1
            Console.WriteLine(searchResponse.Documents.Count);
        }
    }
