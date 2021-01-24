csharp
public class DisallowNullItemsConverter : JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        => serializer.Serialize(writer, value);
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue,
        JsonSerializer serializer)
    {
        var deserialized = serializer.Deserialize(reader, objectType);
        if (deserialized is IEnumerable items && items.Cast<object>().Any(x => x is null))
        {
            const string errorMessage = "No nulls allowed round these parts...";
            if (reader is IJsonLineInfo lineInfo)
            {
                throw new JsonReaderException(errorMessage,
                    reader.Path,
                    lineInfo.LineNumber,
                    lineInfo.LinePosition,
                    null);
            }
            throw new JsonReaderException(errorMessage);
        }
        return deserialized;
    }
    public override bool CanConvert(Type objectType)
        => typeof(IEnumerable).IsAssignableFrom(objectType) && objectType != typeof(string);
}
Use like this:
csharp
public class RootObject
{
    [JsonConverter(typeof(DisallowNullItemsConverter))]
    public List<string> Values { get; set; }
}
