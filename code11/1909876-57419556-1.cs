    class Program
    {
        public class Document
        {
            public int Id { get; set; }
            [Nested]
            public List<Property> Properties { get; set; }
        }
        public class Property
        {
            public string Source { get; set; }
            public string Value { get; set; }
            public override string ToString() => $"Source: {Source} Value: {Value}";
        }
        static async Task Main(string[] args)
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var connectionSettings = new ConnectionSettings(pool);
            connectionSettings.DefaultIndex("documents");
            connectionSettings.DisableDirectStreaming();
            connectionSettings.PrettyJson();
            var client = new ElasticClient(connectionSettings);
            var deleteIndexResponse = await client.Indices.DeleteAsync("documents");
            var createIndexResponse = await client.Indices.CreateAsync("documents", d => d
                .Map(m => m.AutoMap<Document>()));
            var indexDocument = await client
                .IndexDocumentAsync(new Document
                {
                    Id = 1, 
                    Properties = new List<Property>
                    {
                        new Property {Source = "Color", Value = "green"},
                        new Property {Source = "Size", Value = "2"},
                    }
                });
            indexDocument = await client
                .IndexDocumentAsync(new Document
                {
                    Id = 2, 
                    Properties = new List<Property>
                    {
                        new Property {Source = "Color", Value = "blue"},
                        new Property {Source = "Size", Value = "2"},
                    }
                });
            indexDocument = await client
                .IndexDocumentAsync(new Document
                {
                    Id = 3, 
                    Properties = new List<Property>
                    {
                        new Property {Source = "Color", Value = "red"},
                        new Property {Source = "Size", Value = "1"},
                    }
                });
            var refreshAsync = client.Indices.RefreshAsync();
            var query = new BoolQuery
            {
                Must = new QueryContainer[]
                {
                    new NestedQuery
                    {
                        Path = "properties",
                        Query = new BoolQuery()
                        {
                            Must = new QueryContainer[]
                            {
                                new TermQuery()
                                {
                                    Field = new Nest.Field("properties.source.keyword"),
                                    Value = "Color"
                                },
                                new TermsQuery()
                                {
                                    Field = new Nest.Field("properties.value.keyword"),
                                    Terms = new[] {"green", "blue"}
                                }
                            }
                        }
                    },
                    new NestedQuery
                    {
                        Path = "properties",
                        Query = new BoolQuery()
                        {
                            Must = new QueryContainer[]
                            {
                                new TermQuery()
                                {
                                    Field = new Nest.Field("properties.source.keyword"),
                                    Value = "Size"
                                },
                                new TermsQuery()
                                {
                                    Field = new Nest.Field("properties.value.keyword"),
                                    Terms = new[] {"2"}
                                }
                            }
                        }
                    }
                }
            };
            var response = client.Search<Document>(s => s.Query(q => query));
            
            foreach (var document in response.Documents)
            {
                Console.WriteLine($"Id: {document.Id}");
                document.Properties.ForEach(Console.WriteLine);
                Console.WriteLine();
            }
        }
    }
