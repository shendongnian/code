    var client = new ElasticClient();
    var listOfPropertyIds = new [] { 1, 2, 3 };
    // pull the descriptor out of the client API call
    var searchDescriptor = new SearchDescriptor<PropertyRecord>()
        .Query(q => q.Terms(
            c => c
                .Field(f => f.property_id_orig)
                .Terms(listOfPropertyIds) // a list of 20 ids say... 
        ))
        .From(0)
        .Take(100);
    var json = client.RequestResponseSerializer.SerializeToString(searchDescriptor, SerializationFormatting.Indented);
    
    Console.WriteLine(json);
