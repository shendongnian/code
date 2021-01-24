    public class CustomItemConverter : JsonConverter
    {
    	public override bool CanRead => false;
    	
    	public override bool CanConvert(Type objectType)
    	{
    		return objectType == typeof(Dictionary<DateTime, Item[]>);
    	}
    	
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		var dictionary = (Dictionary<DateTime, Item[]>)value;
    		
    		writer.WriteStartArray();
    		foreach (var item in dictionary)
    		{
    			writer.WriteStartObject();
    			writer.WritePropertyName(item.Key.Date.ToString("yyyy-MM-dd"));
    			serializer.Serialize(writer, item.Value);
    			writer.WriteEndObject();
    		}
    		writer.WriteEndArray();
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
    	}
    }
