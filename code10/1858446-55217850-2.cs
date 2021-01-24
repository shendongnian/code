public class TestData
{
    public string Name { get; set; }
    public string Section { get; set; }
    public string Value(string value)
    {
        var val = typeof(TestData).GetProperty(value).GetValue(this);
        // This will return null instead of throwing an exception
        // var val = typeof(TestData).GetProperty(value)?.GetValue(this);
        if (val is string result)
        {
            return result;
        }
        return default;
    }
}
Or with the extension method
public static class TestDataExtensions
{
    public static string Value(this TestData testData, string value)
    {
        var val = typeof(TestData).GetProperty(value).GetValue(testData);
        if (val is string result)
        {
            return result;
        }
        return default;
    }
}
