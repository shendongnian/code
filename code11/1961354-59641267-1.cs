class StringHelper
{
    public string Concat(IEnumerable<string> values)
    {
        lock (_stringBuilder)
        {
            Clear();
            foreach (string value in values)
                _stringBuilder.Append(value);
            return _stringBuilder.ToString();
        }
    }
    public string Concat(params string[] values) {
        return Concat((IEnumerable<string>)values);
    }
}
Now, you can call the `IEnumerable<string>` overload in the extension method:
    public static string Concat(this string str, params string[] values)
    {
        return _stringHelper.Concat(values.Prepend(str));
    }
