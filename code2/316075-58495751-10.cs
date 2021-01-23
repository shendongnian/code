    JsonSerializerOptions options = new JsonSerializerOptions
    {        
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  // set camelCase       
        WriteIndented = true                                // write pretty json
    };
    // pass options to serializer
    var json = JsonSerializer.Serialize(order, options);
    // pass options to deserializer
    var order = JsonSerializer.Deserialize<Order>(json, options);
  
