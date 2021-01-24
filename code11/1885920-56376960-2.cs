    public class ArrayConverter<T> : JsonConverter<T>
    {
    	public override T ReadJson(JsonReader reader, Type objectType, T existingValue, bool hasExistingValue, JsonSerializer serializer)
    	{
    		JToken token = JToken.Load(reader);
            //This isn't the best code but shows you what you need to do.
    		return token.ToObject<List<T>>().First();
    	}
    
    	public override void WriteJson(JsonWriter writer, T value, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
