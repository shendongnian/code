csharp
public class NewtonsoftStringToLongJsonConverter : Newtonsoft.Json.JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		throw new NotImplementedException();
	}
	public override object ReadJson(Newtonsoft.Json.JsonReader reader, Type objectType, object existingValue, Newtonsoft.Json.JsonSerializer serializer)
	{
		var value = (string)reader.Value;
		if (string.Equals("null", value, StringComparison.InvariantCultureIgnoreCase))
		{
			return null;
		}
		if (!long.TryParse(value, out var parsedValue))
		{
			return null;
		}
		return parsedValue;
	}
	public override void WriteJson(Newtonsoft.Json.JsonWriter writer, object value, Newtonsoft.Json.JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}
}
Your model updates to
csharp
public class Class1
{
    public string Name { get; set; }
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftStringToLongJsonConverter))]
    public long? Id { get; set; }
}
The second option using the System.Text.Json implementation.
csharp
public class SystemTextStringToLongJsonConverter : System.Text.Json.Serialization.JsonConverter<long?>
{
    public override bool CanConvert(Type typeToConvert)
        => typeToConvert == typeof(long?);
    public override long? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        var value = reader.GetString();
        if(string.Equals("null", value, StringComparison.InvariantCultureIgnoreCase))
        {
            return null;
        }
        if(!long.TryParse(value, out var parsedValue))
        {
            return null;
        }
        return parsedValue;
    }
    public override void Write(Utf8JsonWriter writer, long? value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
Finally, your model updates to
csharp
public class Class1
{
    public string Name { get; set; }
    [Newtonsoft.Json.JsonConverter(typeof(NewtonsoftStringToLongJsonConverter))]
    public long? Id { get; set; }
}
