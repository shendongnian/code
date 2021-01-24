    var client = new AmazonDynamoDBClient();
    var context = new DynamoDBContext(client);
    
    var filter = new QueryFilter();
    filter.AddCondition(Model.HashKey, QueryOperator.Equal, 123);
    var events = await context.FromQueryAsync<Event>(new QueryOperationConfig
    {
        Select = SelectValues.AllAttributes,
        Filter = filter
    });
