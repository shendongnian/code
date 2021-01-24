    public async Task<T> GetByIdAsync(string id, object partitionKeyValue = null)
            {
                var options = this.EnsureRequestOptions(partitionKeyValue);
    
                var sqlQuery = new QueryDefinition($"select * from {this.containerName} c where c.id = @id").WithParameter("@id", id);
                var iterator = this.container.GetItemQueryIterator<T>(
                    sqlQuery,
                    requestOptions: options);
    
                while (iterator.HasMoreResults)
                {
                    var response = await iterator.ReadNextAsync().AnyContext();
                    this.LogRequestCharge(response.RequestCharge, response.ActivityId);
    
                    foreach (var result in response.Resource)
                    {
                        return result;
                    }
                }
