string inputHtmlColor = "#F3212A";
StatusColor outColor = inputHtmlColor.GetEnumFromString<StatusColor>();
That's how you would call the below extension method.
- I used and modified the below extension method which came from [here](https://stackoverflow.com/a/4367868/9533368)
public static class EnumEx
{
    public static T GetEnumFromString<T>(this string stringValue)
    {
        var type = typeof(T);
        if (!type.IsEnum) throw new InvalidOperationException();
        foreach (var field in type.GetFields())
        {
            var attribute = Attribute.GetCustomAttribute(field,
                typeof(StringValueAttribute)) as StringValueAttribute;
            if (attribute != null)
            {
                if (attribute.Value == stringValue)
                    return (T)field.GetValue(null);
            }
            else
            {
                if (field.Name == stringValue)
                    return (T)field.GetValue(null);
            }
        }
        throw new ArgumentException("Not found.", "stringValue");
        // or return default(T);
    }
}
**note on the Attribute:**
I defined my attribute like this:
public class StringValueAttribute : Attribute
{
    public string Value { get; private set; }
    public StringValueAttribute(string value)
    {
        Value = value;
    }
}
If your `StringValueAttribute` is defined differently, feel free to update your question to include that type definition, and I'll update my answer if necessary.
