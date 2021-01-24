    public class NameCachingJObjectConverter : JsonConverter
    {
    	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    	{
    		// can write is set to false
    	}
    
    	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    	{
    		return ReadValue(reader);
    	}
    
    	private JToken ReadValue(JsonReader reader)
    	{
    		if (!MoveToContent(reader))
    		{
    			throw new Exception("Unexpected end of content");
    		}
    
    		switch (reader.TokenType)
    		{
    			case JsonToken.StartObject:
    				return ReadObject(reader);
    			case JsonToken.StartArray:
    				return ReadList(reader);
    			default:
    				if (IsPrimitiveToken(reader.TokenType))
    				{
    					return new JValue(reader.Value);
    				}
    
    				throw new Exception("Unexpected token when converting object: {reader.TokenType}");
    		}
    	}
    
    	private static bool IsPrimitiveToken(JsonToken token)
    	{
    		switch (token)
    		{
    			case JsonToken.Integer:
    			case JsonToken.Float:
    			case JsonToken.String:
    			case JsonToken.Boolean:
    			case JsonToken.Undefined:
    			case JsonToken.Null:
    			case JsonToken.Date:
    			case JsonToken.Bytes:
    				return true;
    			default:
    				return false;
    		}
    	}
    
        private static bool MoveToContent(JsonReader reader)
    	{
    		JsonToken t = reader.TokenType;
    		while (t == JsonToken.None || t == JsonToken.Comment)
    		{
    			if (!reader.Read())
    			{
    				return false;
    			}
    			t = reader.TokenType;
    		}
    		return true;
    	}
    
    	private JArray ReadList(JsonReader reader)
    	{
    		var list = new JArray();
    
    		while (reader.Read())
    		{
    			switch (reader.TokenType)
    			{
    				case JsonToken.Comment:
    					break;
    				default:
    					object v = ReadValue(reader);
    
    					list.Add(v);
    					break;
    				case JsonToken.EndArray:
    					return list;
    			}
    		}
    
    		throw new Exception("Unexpected end when reading JObject.");
    	}
    
    	private JToken ReadObject(JsonReader reader)
    	{
    		var expandoObject = new JObject();
    
    		while (reader.Read())
    		{
    			switch (reader.TokenType)
    			{
    				case JsonToken.PropertyName:
    					string propertyName = GetCachedName(reader.Value.ToString());
    
    					if (!reader.Read())
    					{
    						throw new Exception("Unexpected end when reading JObject.");
    					}
    
    					var v = ReadValue(reader);
    
    					expandoObject[propertyName] = v;
    					break;
    				case JsonToken.Comment:
    					break;
    				case JsonToken.EndObject:
    					return expandoObject;
    			}
    		}
    
    		throw new Exception("Unexpected end when reading ExpandoObject.");
    	}
    
    	/// <summary>
    	/// Determines whether this instance can convert the specified object type.
    	/// </summary>
    	/// <param name="objectType">Type of the object.</param>
    	/// <returns>
    	/// 	<c>true</c> if this instance can convert the specified object type; otherwise, <c>false</c>.
    	/// </returns>
    	public override bool CanConvert(Type objectType)
    	{
    		return (typeof(JToken).IsAssignableFrom(objectType));
    	}
    
    	/// <summary>
    	/// Gets a value indicating whether this <see cref="JsonConverter"/> can write JSON.
    	/// </summary>
    	/// <value>
    	/// 	<c>true</c> if this <see cref="JsonConverter"/> can write JSON; otherwise, <c>false</c>.
    	/// </value>
    	public override bool CanWrite => false;
    
    
    
    	private string GetCachedName(string value)
    	{
    		string ret;
    		if (!cache.TryGetValue(value, out ret))
    		{
    			cache[value] = value;
    			ret = value;
    		}
    		return ret;
    	}
    	private readonly Dictionary<string, string> cache = new Dictionary<string, string>();
    }
