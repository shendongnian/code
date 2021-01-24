    var settings = GetInfoFromDatabase();
    var factory = ClientObjectFactory.Create(settings);
    
    var clientObject = factory.CreateClientObject();
    clientObject.Post("");  // This could be any of the client objects.  
