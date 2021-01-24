 c#
public class TestJsonConverter : JsonConverter
{
    public TestJsonConverter()
    {
    }
    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        JToken t = JToken.FromObject(value);
        if (t.Type != JTokenType.Object)
        {
            t.WriteTo(writer);
        }
        else
        {
            JObject root = (JObject)t;
            var stack = new Stack<JObject>();
            stack.Push(root);
            while (stack.Any())
            {
                var current = stack.Pop();
                var propertyNames = current.Properties().Select(p => p.Name).ToArray();
                current.AddFirst(new JProperty("Keys", new JArray(propertyNames)));
                var nestedObjects = current.Properties().Where(p => p.Value.Type == JTokenType.Object).ToArray();
                foreach (var nestedObj in nestedObjects)
                {
                    stack.Push((JObject)nestedObj.Value);
                }
            }
            root.WriteTo(writer);
        }
    }
    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        throw new NotImplementedException("Unnecessary because CanRead is false. The type will skip the converter.");
    }
    public override bool CanConvert(Type objectType)
    {
        return (objectType == typeof(Employee));
    }
    public override bool CanRead
    {
        get { return false; }
    }
}
