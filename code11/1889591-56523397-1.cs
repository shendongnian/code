    async Task CreateAndRunDDL(Client client)
    {
        var query = QueryForClient(...);
        LambdaLogger.Log(query);
        if (query.Length >= MaxQueryLength) {
            throw new Exception("Delete partition query length exceeded.");
        }
        var queryExecutionId = await StartQueryExecution(query);
        await CheckQueryExecutionStatus(queryExecutionId);
    }
