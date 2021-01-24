    AmazonDynamoDBClient client = new AmazonDynamoDBClient();
    
    UpdateItemRequest updateItemRequest = new UpdateItemRequest()
    {
    	TableName = "QTrackStatus",
    	ReturnValues = ReturnValue.ALL_NEW,
    	ConditionExpression = "EventCode <> :ec",
    	UpdateExpression = "SET EventCode = :ec, EventDateTime = :edt, EventLocation = :el, EventLastUpdate = :elu",
    	ExpressionAttributeValues = new Dictionary<string, AttributeValue>()
    	{
    		{ ":ec", new AttributeValue("CC") },
    		{ ":edt", new AttributeValue("2019-09-09 14:00:30") },
    		{ ":el", new AttributeValue("BFS") },
    		{ ":elu", new AttributeValue() { N = ((long)(DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1))).TotalSeconds).ToString() } }
    	},
    	Key = new Dictionary<string, AttributeValue>()
    	{
    		{ "Key", new AttributeValue("m@m.com") }
    	}
    };
    
    try
    {
    	UpdateItemResponse updateItemResponse = await client.UpdateItemAsync(updateItemRequest);
    }
    catch(ConditionalCheckFailedException e)
    {
    
    }
