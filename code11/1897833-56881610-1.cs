c#
public class RawConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(string);
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return reader.TokenType != JsonToken.Null
            ? JRaw.Create(reader).ToString()
            : null;
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        writer.WriteRawValue((string)value);
    }
}
The persistable class would look like this:
c#
public class PersistablePerson
{
    public string name {get; set;}
    public int department {get; set;}
    
    [JsonConverter(typeof(RawConverter))] 
    public string addresses {get; set;}
    [JsonConverter(typeof(RawConverter))] 
    public string skill {get; set;}
}
### Approach 2 - using doubled properties
In the persistable class, double the "complex" properties so that every such property is represented by two:
- a string property: included in persistence, ignored by JSON serializer
- a `JToken` property: handled by JSON serializer, excluded from persistence
The `JToken` property setter and getter are wrappers that read and write the string property.
c#
public class PersistablePerson
{
    public string name {get; set;}
    public int department {get; set;}
    
    [JsonIgnore] // exclude from JSON serialization, include in persistence
    public string addresses {get; set;}
    [IgnoreProperty]            // exclude from persistence
    [JsonProperty("addresses")] // include in JSON serilization
    public JToken addressesJson
    {
        get { return addresses != null ? JToken.Parse(addresses) : null; }
        set { addresses = value.ToString(); }
    }
    [JsonIgnore] // exclude from JSON serialization, include in persistence
    public string skill {get; set;}
    [IgnoreProperty]        // exclude from persistence
    [JsonProperty("skill")] // include in JSON serilization
    public JToken skillJson
    {
        get { return skill != null ? JToken.Parse(skill) : null; }
        set { skill = value.ToString(); }
    }
}
