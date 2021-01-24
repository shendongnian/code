lang:c#
public class ShortNameOptionComparer : IEqualityComparer<string[]>
{
    public bool Equals(string[] x, string[] y)
    {
        return string.Equals(x[0], y[0], StringComparison.OrdinalIgnoreCase);
    }
    public int GetHashCode(string[] obj)
    {
        return obj[0].GetHashCode();
    }
}
... and plug it into the dictionary:
lang:c#
private Dictionary<string[], ICommand> commandsWithAttributes = new Dictionary<string[], ICommand>(new ShortNameOptionComparer());
To lookup a command we have to use a `string[]` that contains only the short name i.e. `-t`: `var value = dictionary[new [] { "-t" }]`. Or wrap this inside an extension method:
public static class CompositeKeyDictionaryExtensions
{
    public static T GetValueByPartialKey<T>(this IDictionary<string[], T> dictionary, string partialKey)
    {
        return dictionary[new[] { partialKey }];
    }
}
... and use it to get the value:
var value = dictionary.GetValueByPartialKey("-t");
