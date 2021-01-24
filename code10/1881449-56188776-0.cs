    public class PriceConverter : JsonConverter<Price>
    {
    	public override Price ReadJson(JsonReader reader, Type objectType, Price existingValue, 
            bool hasExistingValue, JsonSerializer serializer)
    	{
    		var value = Convert.ToDecimal(reader.Value);
    		return new Price { Value = value };
    	}
    
    	public override void WriteJson(JsonWriter writer, Price value, JsonSerializer serializer)
    	{
    		writer.WriteValue(value.Value);
    	}
    }
