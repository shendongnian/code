    class Program
    {
        static async Task Main(string[] args)
        {
            var connectionPool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var settings = new ConnectionSettings(connectionPool)
                .DefaultIndex("index_name")
                .DisableDirectStreaming()
                .PrettyJson();
            var client = new ElasticClient(settings);
            
            await client.Indices.DeleteAsync("index_name");
            var createIndexResponse = await client.Indices.CreateAsync("index_name",
                c => c
                    .Map(map => map.AutoMap<Document>()));
            await client.IndexManyAsync(new []
                {new Document {Id = 1, Text = "παγωτό"}, new Document {Id = 2, Text = "παγωτο"},});
            await client.Indices.RefreshAsync();
            var query = "παγωτό";
            var searchResponse = await client.SearchAsync<Document>(s => s
                .Query(q => q.Match(m => m.Field(f => f.Text).Query(query))));
            
            Console.OutputEncoding = Encoding.UTF8;
            
            Print(query, searchResponse);
            query = "παγωτο";
            var searchResponse2 = await client.SearchAsync<Document>(s => s
                .Query(q => q.Match(m => m.Field(f => f.Text).Query(query))));
            Print(query, searchResponse2);
        }
        private static void Print(string query, ISearchResponse<Document> searchResponse)
        {
            Console.WriteLine($"For {query} found:");
            foreach (var document in searchResponse.Documents)
            {
                Console.WriteLine($"Document {document.Id} {document.Text}");
            }
        }
    }
    public class Document
    {
        public int Id { get; set; }
        [Text(Analyzer = "greek")]
        public string Text { get; set; }
    }
