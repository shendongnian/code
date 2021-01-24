public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
{
	JToken t = JToken.FromObject(value);
	if (t.Type != JTokenType.Object)
	{
		t.WriteTo(writer);
	}
	else
	{
		JObject o = (JObject)t;
		var property = o.Properties().FirstOrDefault(p => p.Name == "CreatedBy");
		if(property != null)
        {
			o.Remove(property.Name);
			var newObj = new JObject();
			newObj.Add(new JProperty("Id",((JObject)property.Value).Properties().First(p => p.Name == "Id").Value));
			var newProperty = new JProperty(property.Name, newObj);
			o.Add(newProperty);
			o.WriteTo(writer);
        }
	}
}
And the serialization code would be like this:
var json = JsonConvert.SerializeObject(questions,  // your list of 'Question'
                                       Newtonsoft.Json.Formatting.Indented, 
                                       new MyCustomJsonConverter(typeof(Question)));
  [1]: https://www.newtonsoft.com/json/help/html/CustomJsonConverter.htm
