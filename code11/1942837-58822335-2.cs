    public void WriteErrorLogs(Error entity, string collectionName)
    {
        try
        {
            Container container = cosmosclient.GetContainer(databaseName, collectionName);
            entity.LogID = Guid.NewGuid().ToString();          
            container.CreateItemAsync<Error>(entity, new PartitionKey(entity.LogID)).GetAwaiter().GetResult();
            // or ItemResponse<Error> response = container.CreateItemAsync<Error>(entity, new PartitionKey(entity.LogID)).Result;
            // or container.CreateItemAsync<Error>(entity, new PartitionKey(entity.LogID)).Wait();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
