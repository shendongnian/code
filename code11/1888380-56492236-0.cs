public static class JsonExtensions
{
    public static void SetValue(this JContainer container, string path, object value)
    {
        JToken token = container;
        var keys = path.Split('.');
        foreach (var key in keys)
        {
            int index;
            if (int.TryParse(key, out index))
            {
                var jArray = token as JArray;
                if (jArray == null)
                {
                    jArray = new JArray();
                    token.Replace(jArray);
                    token = jArray;
                }
                while (index >= jArray.Count)
                {
                    jArray.Add(JValue.CreateNull());
                }
                token = jArray[index];
            }
            else
            {
                var jObject = token as JObject;
                if (jObject == null)
                {
                    jObject = new JObject();
                    token.Replace(jObject);
                    token = jObject;
                }
                token = token[key] ?? (token[key] = JValue.CreateNull());
            }
        }
        token.Replace(new JValue(value));
    }
    public static void SetValues(this JContainer container, IEnumerable<KeyValuePair<string, object>> pairs)
    {
        foreach (var pair in pairs)
        {
            container.SetValue(pair.Key, pair.Value);
        }
    }
}
And here's how you get the results you expect:
var jObject = new JObject();
jObject.SetValues(new Dictionary<string, object>
{
    { "content", "button" },
    { "page.count", "10" },
    { "columns.0.textAlign", "center" },
    { "columns.1.textAlign", "left" }
});
Console.WriteLine(jObject.ToString(Formatting.Indented));
Note that the code sample I provided is no way near efficient and should be used just as an inspiration to achieve the result you require.
Also note that in some cases the order of values to build the `JObject` matters, but [enumerating items from dictionary is non-deterministic][1]. Therefore you might consider a better data structure for the source that guarantees order of key-value pairs in it such as an array.
  [1]: https://stackoverflow.com/questions/4007782/the-order-of-elements-in-dictionary
