    internal class Person
    	{
    		public int id { get; set; }
    		public string firstname { get; set; }
    		public string lastname { get; set; }
    		public string Mnumber { get; set; }
    		public string Email { get; set; }
    
    	}
    	
    			var settings = new ConnectionSettings(new Uri("http://localhost:9200"));
    
    			settings.DefaultIndex("bar");
    
    			var client = new ElasticClient(settings);
    			
    			
    			
    			var person = new Person
    			{
    				id = 2,
    				firstname = "Martijn123Hitesh",
    				lastname = "Martijn123",
    				Mnumber="97224261678",
    				Email="hitesh@gmail.com"
    			};
    
    			var indexedResult = client.Index(person, i => i.Index("bar"));
    			
    			 var searchResponse = client.Search<Person>(s => s
                .Index("bar")
                .Query(q => q
                        .Match(m => m
                        .Field(f => f.firstname)
                        .Query("Martijn123Hitesh")
                        )
                )
              );
    			
    			
    			
