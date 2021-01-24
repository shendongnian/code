    class Program
    {
        public class Document
        {
            public int Id { get; set; }
            public bool IsActive { get; set; }
        }
        static async Task Main(string[] args)
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var connectionSettings = new ConnectionSettings(pool);
            connectionSettings.DefaultIndex("documents");
            var client = new ElasticClient(connectionSettings);
            var deleteIndexResponse = await client.Indices.DeleteAsync("documents");
            var createIndexResponse = await client.Indices.CreateAsync("documents", d => d
                .Map(m => m.AutoMap<Document>()));
            var indexDocument = await client.IndexDocumentAsync(new Document {Id = 1});
            var refreshAsync = client.Indices.RefreshAsync();
            var putMappingResponse = await client.MapAsync<Document>(m => m
                .AutoMap());
            var updateByQueryResponse = await client.UpdateByQueryAsync<Document>(u => u
                .Query(q => q.MatchAll())
                .Script("ctx._source.isActive = true")
                .Refresh());
            var response = await client.GetAsync<Document>(1);
            Console.WriteLine(response.Source.IsActive);
        }
    }
