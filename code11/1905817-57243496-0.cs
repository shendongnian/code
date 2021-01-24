        public class Document
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Brand { get; set; }
            public string Category { get; set; }
            public override string ToString() => $"Id: {Id} Name: {Name} Brand: {Brand} Category: {Category}";
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
            var indexDocument = await client
                .IndexDocumentAsync(new Document {Id = 1, Brand = "Tommy", Category = "men"});
            var indexDocument2 = await client
                .IndexDocumentAsync(new Document {Id = 2, Brand = "Diesel", Category = "men"});
            var indexDocument3 = await client
                .IndexDocumentAsync(new Document {Id = 3, Brand = "Boss", Category = "men"});
            var refreshAsync = client.Indices.RefreshAsync();
            var query = "Tommy";
            var searchResponse = await Search(client, query);
            PrintResults(query, searchResponse);
            
            query = "Tommy men";
            searchResponse = await Search(client, query);
            PrintResults(query, searchResponse);
            
            query = "men";
            searchResponse = await Search(client, query);
            PrintResults(query, searchResponse);
        }
        private static async Task<ISearchResponse<Document>> Search(ElasticClient client, string query)
        {
            var searchResponse = await client.SearchAsync<Document>(s => s.Query(q => q
                .MultiMatch(mm => mm
                    .Fields(f => f.Fields(ff => ff.Brand, ff => ff.Category, ff => ff.Name))
                    .Query(query)
                    .Type(TextQueryType.CrossFields)
                    .MinimumShouldMatch("100%"))));
            return searchResponse;
        }
        private static void PrintResults(string query, ISearchResponse<Document> searchResponse)
        {
            Console.WriteLine($"query: {query}");
            Console.WriteLine(searchResponse.Total);
            Console.WriteLine($"results: ");
            searchResponse.Documents.ToList().ForEach(Console.WriteLine);
            Console.WriteLine();
        }
    }
