 var json = JsonConvert.SerializeObject(o, new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            });
----
#Update
Since fully indented json is not good enough you could try a custom converter.
## Result
{"Property1":"value1","Property2":"value2","Property3":["test","test1","test3"]
,"Property4":"value4","Property5":"value5","Property6":"value6"
,"Time":"00:00:13","Property7":"value7","Property8":"value8"
,"Property9":"value9","Property10":"value10","Property11":["asdf","basdf"]
}
## Converter
public class CustomLineBreakerConverter : JsonConverter
{
  private readonly uint n;
  private uint i = 1;
  public CustomLineBreakerConverter(uint n) { this.n = n; }
  public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
  {
    // Scaffolding from https://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm
    JToken t = JToken.FromObject(value);
    if (t.Type != JTokenType.Object)
    {
      t.WriteTo(writer);
    }
    else
    {
      JObject o = (JObject)t;
      var properties = o.Properties();
      writer.WriteStartObject();
      foreach( var p in properties)
      {
        p.WriteTo(writer);
        if (i++ % n == 0)
        {
          writer.WriteWhitespace("\r\n");  // This will write a new line after the property even if no more properties
        }
      }
      writer.WriteEndObject();
    }
  }
  public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
     => throw new NotImplementedException("This converter is meant only for writing");
  public override bool CanConvert(Type objectType) => true;
}
## Test code
var o = new
{
	Property1 = "value1",
	Property2 = "value2",
	Property3 = new[] { "test", "test1", "test3" },
	Property4 = "value4",
	Property5 = "value5",
	Property6 = "value6",
	Time = TimeSpan.FromSeconds(13),
	Property7 = "value7",
	Property8 = "value8",
	Property9 = "value9",
	Property10 = "value10",
	Property11 = new string[] { "asdf", "basdf" }
};
var json = JsonConvert.SerializeObject(o, new JsonSerializerSettings
{
	Formatting = Formatting.None,
	Converters = new List<JsonConverter>() { new CustomLineBreakerConverter(3) }
});
Console.WriteLine(json);
