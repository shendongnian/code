    // Create Cosmos Storage
    private static readonly CosmosDbStorage _myStorage = new CosmosDbStorage(new CosmosDbStorageOptions
    {
       AuthKey = CosmosDBKey,
       CollectionId = CosmosDBCollectionName,
       CosmosDBEndpoint = new Uri(CosmosServiceEndpoint),
       DatabaseId = CosmosDBDatabaseName,
    });
    
    // Write
    var userData = new { Name = "xyz", Email = "xyz@email.com", Message = "my message" };
    var changes = Dictionary<string, object>();
    {
        changes.Add("UserId", userData);
    };
    await _myStorage.WriteAsync(changes, cancellationToken);
    
    // Read
    var userDataFromStorage = await _myStorage.read(["UserId"]);
