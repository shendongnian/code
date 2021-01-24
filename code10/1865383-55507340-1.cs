    var defaultIndex = "properties_example";
    var pool = new SingleNodeConnectionPool(new Uri("http://localhost:9200"));
    var settings = new ConnectionSettings(pool)
        .DefaultIndex(defaultIndex);
    var client = new ElasticClient(settings);
	
	if (!client.IndexExists(defaultIndex).Exists)
	{
		var createIndexResponse = client.CreateIndex(defaultIndex, c => c
			.Mappings(m => m
				.Map<Document>(mm => mm.AutoMap())
			)
		);
	}
	var properties = new PropertyWalker(typeof(Document), null).GetProperties();
    // will use the index inferred for Document, or the default index if none
    // specified. Can specify an index on this call if you want to	
	var getMappingResponse = client.GetMapping<Document>();
	
	var indexedMappings = getMappingResponse
        // Use the index name to which the call was made.
		.Indices[defaultIndex]
		.Mappings[typeof(Document)]
		.Properties;
	
	var propertiesToIndex = new Dictionary<PropertyName, IProperty>();	
	foreach(var property in properties)
	{
		if (!indexedMappings.ContainsKey(property.Key))
		{
			propertiesToIndex.Add(property.Key, property.Value);
		}
	}
    // map new properties only if there are some to map
	if (propertiesToIndex.Any())
	{
		var request = new PutMappingRequest<Document>()
		{
			Properties = new Properties(propertiesToIndex)
		};
		var putMappingResponse = client.Map(request);
	}
