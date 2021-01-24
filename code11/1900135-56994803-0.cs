    class Program
    {
        public class Document  
        {
            public int Id { get; set; }
            public DateTime Timestamp { get; set; }
            public string CustomerName { get; set; }
            public string MobileNumber { get; set; }
        } 
        
        static async Task Main(string[] args)
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var connectionSettings = new ConnectionSettings(pool);
            connectionSettings.DefaultIndex("documents");
            
            var client = new ElasticClient(connectionSettings);
            await client.Indices.DeleteAsync("documents");
            await client.Indices.CreateAsync("documents");
            var response = await client.IndexAsync(
                new Document
                {
                    Id = 1, 
                    Timestamp = new DateTime(2010, 01, 01, 10, 0, 0),
                    MobileNumber = "3530831112233",
                    CustomerName = "Robert"
                }, descriptor => descriptor);
            await client.Indices.RefreshAsync();
            string query = "8311122";
            var result = await client.SearchAsync<Document>(s => s
                .Query(q => q.Bool(b => b
                    .Should(
                        sh => sh.Match(m => m.Field(f => f.CustomerName).Query(query)),
                        sh => sh.Wildcard(w => w.Field(f => f.MobileNumber.Suffix("keyword")).Value($"*{query}*"))))));
            
            foreach (var document in result.Documents)
            {
                Console.WriteLine(document.Id);
            }
        }
    }
