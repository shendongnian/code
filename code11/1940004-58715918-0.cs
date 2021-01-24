    public class NaicsConverter : JsonConverter
    {
    	public override bool CanConvert(Type t) => t == typeof(Naics);
    
    	public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
    	{
    		var naics = new Naics();
    		
    		switch (reader.TokenType)
    		{
    			case JsonToken.StartObject:
                    // We know this is an object, so serialise a single Naics
    				naics.Add(serializer.Deserialize<Naic>(reader));
    				break;
    				
    			case JsonToken.StartArray:
                    // We know this is an object, so serialise multiple Naics
    				foreach(var naic in serializer.Deserialize<List<Naic>>(reader))
    				{
    					naics.Add(naic);
    				}
    				break;
    		}
    		
    		return naics;
    	}
    
    	public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
    	{
    		throw new NotImplementedException();
    	}
    }
