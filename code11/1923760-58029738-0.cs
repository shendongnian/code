    AmazonDynamoDBClient client = new AmazonDynamoDBClient();
    
    var request = new QueryRequest
    {
        TableName = "Reply",
        KeyConditionExpression = "Id = :v_Id",
        ExpressionAttributeValues = new Dictionary<string, AttributeValue> {
            {":v_Id", new AttributeValue { S =  "Amazon DynamoDB#DynamoDB Thread 1" }}}
    };
    
    var response = client.Query(request);
    
    foreach (Dictionary<string, AttributeValue> item in response.Items)
    {
        // Process the result.
        PrintItem(item);
    } 
