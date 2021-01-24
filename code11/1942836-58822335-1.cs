    public async Task WriteErrorLogs(Error entity, string collectionName)
    {
        try
        {
            Container container = cosmosclient.GetContainer(databaseName, collectionName);
            entity.LogID = Guid.NewGuid().ToString();          
            await container.CreateItemAsync<Error>(entity, new PartitionKey(entity.LogID));
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
