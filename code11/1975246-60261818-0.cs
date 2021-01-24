csharp
public class MyClass
{
    [JsonConverter(typeof(JsonTypeConverter))]
    public Type Type { get; set; }
}
public class JsonTypeConverter: JsonConverter
{
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var type = value as Type;
        writer.WriteValue(type.Name);
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
    }
    public override bool CanRead
    {
        get { return false; }
    }
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Type);
    }
}
