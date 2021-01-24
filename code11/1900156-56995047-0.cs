    class Program
    {
        public class DynamicDocument : Dictionary<string, object>
        {
            public string Id => this["id"]?.ToString();
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
                new DynamicDocument
                {
                    {"id", "1"}, 
                    {"field1", "value"}, 
                    {"field2", 1}
                }, descriptor => descriptor);
            //will update document with id 1 as it's already exists
            await client.IndexManyAsync(new[]
            {
                new DynamicDocument
                {
                    {"id", "1"},
                    {"field1", "value2"},
                    {"field2", 2}
                }
            }); 
            await client.Indices.RefreshAsync();
            var found = await client.GetAsync<DynamicDocument>("1");
            Console.WriteLine($"Id: {found.Source.Id}");
            Console.WriteLine($"field1: {found.Source["field1"]}");
            Console.WriteLine($"field2: {found.Source["field2"]}");
        }
    }
