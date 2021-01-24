    public async Task<int> GetMaxId()
    {
    	try
    	{
    		var maxValue = 0;
    		var option = new FeedOptions { EnableCrossPartitionQuery = true };
    		// SQL
    		var familiesSqlQuery = client.CreateDocumentQuery(cosmosConnector,
    			"SELECT c.id FROM c", option).AsDocumentQuery();
    		
    		while(familiesSqlQuery.HasMoreResults)
    		{
    			var ids = await familiesSqlQuery.ExecuteNextAsync();
                var maxIdInBatch = ids.Select(int.Parse).Max();
    			if(maxIdInBatch > maxValue)
    			{
    				maxValue = maxIdInBatch;
    			}			
    		}
    		
    		return maxValue;
    	}
    	catch
    	{
    		throw;
    	}
    }
