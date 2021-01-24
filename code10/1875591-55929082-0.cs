public class BaseTag
{
	public string TagName { get; set; }
	public int DataType { get; set; }
	public bool IsRequired { get; set; }
}
public sealed class ListTag : BaseTag
{
	public ICollection<string> Values { get; set; }
}
public sealed class RangeTag: BaseTag
{
	public int Min { get; set; }
	public int Max { get; set; }
}
Then, the custom `PolymorphicTagJsonConverter`
public class PolymorphicTagJsonConverter : JsonConverter
{
	public override bool CanWrite => false;
	public override bool CanConvert(Type objectType) 
		=> typeof(BaseTag).IsAssignableFrom(objectType);
	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		=> throw new NotImplementedException();
	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
	{
		if (reader == null) throw new ArgumentNullException("reader");
		if (serializer == null) throw new ArgumentNullException("serializer");
		if (reader.TokenType == JsonToken.Null)
			return null;
		var jObject = JObject.Load(reader);
		var target = CreateTag(jObject);
		serializer.Populate(jObject.CreateReader(), target);
		return target;
	}       
    
	private BaseTag CreateTag(JObject jObject)
	{
		if (jObject == null) throw new ArgumentNullException("jObject");
		if (jObject["DataType"] == null) throw new ArgumentNullException("DataType");
		switch ((int)jObject["DataType"])
		{
			case 5:
				return new ListTag();
			case 6:
				return new RangeTag();
			default:
				return new BaseTag();
		}
	}
}
The heavy work is done in `ReadJson` and `Create` methods. `Create` receives an `JObject` and inside it inspects the `DataType` property to figure out which type of `Tag` it is. Then, `ReadJson` just proceeds calling the `Populate` on the `JsonSerializer` for the appropriate `Type`.
You need to tell the framework to use your custom converter then:
[JsonConverter(typeof(PolymorphicTagJsonConverter))]
public class BaseTag 
{ 
   // the same as before
}
Finally, you can just have one `POST` endpoint that will accept all types of tags:
[HttpPost]
public IActionResult Post(ICollection<BaseTag> tags)
{
	return Ok(tags);
}
One downside is that `switch` on the converter. You might be okay or not with it.. you could do some smart work and try to make the tag classes implement somehow some interface so you could just call `Create` on the `BaseTag` and it would forward the call to the correct one at runtime, but I guess you can get started with this, and if complexity increases then you can think on a smarter/more automatic way of finding the correct `Tag` classes. 
