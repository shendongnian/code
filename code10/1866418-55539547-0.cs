[JsonConverter(typeof(HasValueConverter))]
public class HasValue
{
    public HasValue(string value)
    {
        this.Value = value;
    }
    public string Value { get; set; }
}
[JsonObject]
public class Thing<T> where T: class
{
    [JsonProperty("value")]
    public T Data { get; set; }
    [JsonProperty("error")]
    public int ErrorCode { get; set; }
}
class HasValueConverter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(HasValue);
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        return new HasValue(JToken.Load(reader).Value<string>());
    }
    public override bool CanWrite => false;
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        throw new NotImplementedException();
    }
}
[Test]
public void Deserializes()
{
    var json = "{ value: \"content\", error: 1 }";
    var thing = JsonConvert.DeserializeObject<Thing<HasValue>>(json);
    Assert.AreEqual("content", thing.Data.Value);
}
