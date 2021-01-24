    public static IEnumerable<object> GetPropertyValues<T>(T input)
    {
        return input.GetType()
            .GetProperties()
            .Select(p => p.GetValue(input));
    }
