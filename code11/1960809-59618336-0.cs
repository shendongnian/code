csharp
public class SearchableList<T> : List<T>
{
	public object this[string item]
	{
		get { 
			var listItem = this.Cast<IDictionary<string, object>>().First(l => l.ContainsKey(item)); // I am assuming that your top level array items will only have one matching key
			return listItem[item];
		}
	}
}
public class MyConverter : ExpandoObjectConverter
{
	static bool IsPrimitiveToken(JsonToken token)
	{
		if ((uint)(token - 7) <= 5u || (uint)(token - 16) <= 1u)
		{
			return true;
		}
		return false;
	}
	bool MoveToContent(JsonReader reader)
	{
		JsonToken tokenType = reader.TokenType;
		while (tokenType == JsonToken.None || tokenType == JsonToken.Comment)
		{
			if (!reader.Read())
			{
				return false;
			}
			tokenType = reader.TokenType;
		}
		return true;
	}
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		return ReadValue(reader);
	}
	private object ReadValue(JsonReader reader)
	{
		if (!MoveToContent(reader))
		{
			throw new JsonSerializationException("Unexpected end when reading ExpandoObject.");
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
					return reader.Value;
				}
				throw new JsonSerializationException("Unexpected token when converting ExpandoObject");
		}
	}
	private object ReadList(JsonReader reader)
	{
		IList<object> list = new SearchableList<object>(); // it is quite unfortunate to have to reimplement all class just because of this one line.
		while (reader.Read())
		{
			switch (reader.TokenType)
			{
				case JsonToken.EndArray:
					return list;
				case JsonToken.Comment:
					continue;
			}
			object item = ReadValue(reader);
			list.Add(item);
		}
		throw new JsonSerializationException("Unexpected end when reading ExpandoObject.");
	}
	private object ReadObject(JsonReader reader)
	{
		IDictionary<string, object> dictionary = new ExpandoObject();
		while (reader.Read())
		{
			switch (reader.TokenType)
			{
				case JsonToken.PropertyName:
					{
						string key = reader.Value.ToString();
						if (!reader.Read())
						{
							throw new JsonSerializationException("Unexpected end when reading ExpandoObject.");
						}						
						object obj2 = dictionary[key] = ReadValue(reader);
						break;
					}
				case JsonToken.EndObject:
					return dictionary;
			}
		}
		throw new JsonSerializationException("Unexpected end when reading ExpandoObject.");
	}
}
void Main()
{
	var myConverter = new MyConverter();
	dynamic entries = JsonConvert.DeserializeObject<ExpandoObject>("your json here", myConverter);
	Console.WriteLine(entries.entries["2019"]["january"]["6"]["name"]);
}
you will notice, `MyConverter` has a lot of seemingly unrelated code, which is a bit unfortunate consequence of how `ExpandoObjectConverter` has pretty limited extensibility out of the box. You could potentially do just with stock standard `ExpandoObjectConverter` but the object it produces gets a bit awkward to traverse given your source json format.
Hopefully this gives you an avenue to explore.
  [1]: https://www.newtonsoft.com/json
