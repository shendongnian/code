[JsonConverter(typeof(JSONTreeConverter))]
public abstract class Node
[JsonConverter(typeof(JSONTreeConverter))]
public class Item
this enables each class to use the custom converter before initializing.
Then the custom converter returns an object which is cast through reflection to the proper Node or Item type.
public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
{
	object targetObj = null;
	JObject jo = JObject.Load(reader);
	try
	{
		targetObj = Activator.CreateInstance(objectType); //instantiating concrete and known types
	}
	catch (Exception exc)
	{
		switch ((Node.NodeType)jo["Type"].Value<int>())
		{
			case Node.NodeType.Root:
				targetObj = new Root();
				break;
			case Node.NodeType.Group:
				targetObj = new Group();
				break;
			case Node.NodeType.Category:
				targetObj = new ValescoCategory();
				break;
			case Node.NodeType.Type:
				targetObj = new Type();
				break;
			case Node.NodeType.SubType:
				targetObj = new SubType();
				break;
			case Node.NodeType.SubsubType:
				targetObj = new SubSubType();
				break;
			case Node.NodeType.Item:
				targetObj = new Item(); //now this is possible ;)
				break;
		}
	}
	foreach (PropertyInfo prop in objectType.GetProperties().Where(p => p.CanRead && p.CanWrite))
	{
		JsonPropertyAttribute att = prop.GetCustomAttributes(true)
										.OfType<JsonPropertyAttribute>()
										.FirstOrDefault();
		string jsonPath = (att != null ? att.PropertyName : prop.Name);
		JToken token = jo.SelectToken(jsonPath);
		if (token != null && token.Type != JTokenType.Null)
		{
			object value = token.ToObject(prop.PropertyType, serializer);
			prop.SetValue(targetObj, value, null);
		}
	}
	return targetObj;
}
