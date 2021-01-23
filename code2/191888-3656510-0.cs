    public static class DictionaryHelper
    {
        public static TKey GetKeyFromValue<TKey, TValue>(this IDictionary<TKey, TValue> instance, TValue value)
        {
            foreach (var kvp in instance)
            {
                if (kvp.Value.Equals(value))
                    return kvp.Key;
            }
            return default(TKey);
        }
    }
    public class Example
    {
        public static void Main(string[] argv)
        {
            Dictionary<string, string> test = new Dictionary<string, string> { { "Mykey", "MyValue" }, { "Key1", "Value2" } };
            string key = test.GetKeyFromValue("MyValue");
        }
    }
