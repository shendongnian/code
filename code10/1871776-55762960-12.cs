    private static IEnumerable<Func<T, string>> GetStringMemberFunctions<T>()
    {
        var result = new List<Func<T, string>>();
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            result.Add(item => (string)property.GetValue(item));
        }
        var fields = typeof(T).GetFields(BindingFlags.Public | BindingFlags.Instance);
        foreach (var field in fields)
        {
            result.Add(item => (string)field.GetValue(item));
        }
        return result;
    }
