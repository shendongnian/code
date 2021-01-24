    // Property on you deserialization object
    public Dictionary<string, Fullfillment> fulfillmentDictionary {get; set;}
    
    // Creating the list for easier use of the data
    List<Fullfillment> fulfillments = fulfillmentDictionary.Values.ToList();
