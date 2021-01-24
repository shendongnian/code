    class Program
    {
        public class Person  
        {
            [Number(Name="person_id")]
            public int Id { get; set; }
            [Date(Name = "person_created")]
            public DateTime Created { get; set; }
        }
        public class Work 
        {
            [Number(Name="work_id")]
            public int Id { get; set; }
            [Date(Name = "work_created")]
            public DateTime Created { get; set; }
        }
        
        static void Main(string[] args)
        {
            var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
            var connectionSettings =
                new ConnectionSettings(pool,
                    sourceSerializer: (builtin, settings) => new JsonNetSerializer(builtin, settings,
                        () => new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All}
                    ));
            var client = new ElasticClient(connectionSettings);
            var deleteIndexResponse = client.Indices.Delete("person,work");
            
            var createIndexResponse = client.Indices
                .Create("person", i => i.Map<Person>(m => m.AutoMap()));
            var createIndexResponse2 = client.Indices
                .Create("work", i => i.Map<Work>(m => m.AutoMap()));
            client.Index(new Person {Id = 1, Created = DateTime.UtcNow},
                i => i.Index("person"));
            client.Index(new Work {Id = 1, Created = DateTime.UtcNow},
                i => i.Index("work"));
            client.Indices.Refresh();
            var searchResponse = client.Search<object>(s => s
                .Index("person,work")
                .Query(q => q.MatchAll()));
            
            foreach (var document in searchResponse.Documents)
            {
                Console.WriteLine($"Person? {document is Person} Work? {document is Work}");
            }
        }
    }
