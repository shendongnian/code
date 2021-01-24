cs
public interface ISerializerSettings
{
	JsonSerializerSettings serializerSettings { get;}
}
class TypeA : ISerializerSettings
{
	public string Name { get; set; }
	public int intPropertyA { get; set; }
	public string strPropertyA { get; set; }
	[JsonIgnore]
	public JsonSerializerSettings serializerSettings { get; } = new JsonSerializerSettings
	{
		Formatting = Formatting.Indented
	};
}
class TypeB : ISerializerSettings
{
	public string Name { get; set; }
	public int intPropertyB { get; set; }
	public string strPropertyB { get; set; }
	[JsonIgnore]
	public JsonSerializerSettings serializerSettings { get; } = new JsonSerializerSettings
	{
		Formatting = Formatting.None
	};
}
class TypeC : ISerializerSettings
{
	public string Name { get; set; }
	public int intPropertyC { get; set; }
	public string strPropertyC { get; set; }
	[JsonIgnore]
	public JsonSerializerSettings serializerSettings { get; } = new JsonSerializerSettings
	{
		Formatting = Formatting.Indented
	};
}
Then in the converter, use the type's settings:
cs
public class CompositeJsonConverter : JsonConverter
{
	public override bool CanConvert(Type objectType)
	{
		return typeof(ISerializerSettings).IsAssignableFrom(objectType);
	}
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		throw new NotImplementedException();
	}
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
	{
		writer.WriteRaw(JsonConvert.SerializeObject(value, ((ISerializerSettings)value).serializerSettings));
	}
}
Finally, in your program, tell the serializer to use your converter:
    string jsonStr = JsonConvert.SerializeObject(testRoot, new CompositeJsonConverter());
Given _this_ input:
cs
TypeA objA = new TypeA(); // assume all values initialized
TypeB objB = new TypeB(); // assume all values initialized
TypeC objC = new TypeC(); // assume all values initialized
object[] resultList = new object[] {
			objA, objB, objC
};
object testRoot = new
{
	Test = "All the test results",
	date = "",
	Results = resultList
};
string jsonStr = JsonConvert.SerializeObject(testRoot, new CompositeJsonConverter());
This is the output: note that TypeB has no formatting, but the others do:
js
{"Test":"All the test results","date":"","Results":[{
  "Name": null,
  "intPropertyA": 0,
  "strPropertyA": null
}{"Name":null,"intPropertyB":0,"strPropertyB":null}{
  "Name": null,
  "intPropertyC": 0,
  "strPropertyC": null
}]}
