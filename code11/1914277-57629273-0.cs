public class EscapeQuotes : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string);
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        var escapedValue = ((string)value).Replace("'", "\\'");
        writer.WriteValue(escapedValue);
    }
}
Usage:
    Customer myObject = new SO.Customer() { Name = "Bob's repair shop" };
    var output = JsonConvert.SerializeObject(myObject, new EscapeQuotes());
Output:
> {"Name":"Bob\\\'s repair shop"}
