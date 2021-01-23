    // Instantiate & populate the object to be serialized to JSON
    SomeClass xyz = new SomeClass();
    ... populate it ...
    
    // Now serialize it
    DataContractJsonSerializer ser = new DataContractJsonSerializer(xyz.GetType()); // Note xyz.GetType()
    ... serialize the object to json, many steps omitted here for brevity ...
    string json = sr.ReadToEnd();
    
