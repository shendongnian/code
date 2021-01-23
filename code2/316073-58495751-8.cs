    JsonSerializerOptions options = new JsonSerializerOptions
    {        
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,  // set camelCase       
        WriteIndented = true   // write pretty json
    };
    // serialize using options
    var json = JsonSerializer.Serialize(order, options);
    // deserialize using options
    var order = JsonSerializer.Deserialize<Order>(json, options);
    
  
