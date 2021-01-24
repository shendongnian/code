    public class MyResponseConverter : JsonConverter
    {
    	public override bool CanConvert(Type type) => type == typeof(MyResponse);
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		var responseObject = JObject.Load(reader);
    
    		MyResponse response = new MyResponse
    		{
    			StartTime = (string)responseObject["starttime"],
    			EndTime = (string)responseObject["endtime"],
    		};
    
    		var varData = new Dictionary<string, object>();
    		
    		foreach (var property in responseObject.Properties())
    		{
    			if(property.Name == "starttime" || property.Name == "endtime")
    			{
    				continue;
    			}
    			
    			varData.Add(property.Name, property.Value);
    		}
    		
    		response.VarData = varData;
    		return response;
    	}
    
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
            // If you want to write to JSON, you will need to implement this method
    		throw new NotImplementedException();
    	}
    }
