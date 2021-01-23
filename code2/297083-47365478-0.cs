    private static Func<string, T> GetParser<T>()
    {
        // The method we are searching for accepts a single string.
        // You can add other types, like IFormatProvider to target specific overloads.
        var signature = new[] { typeof(string) };
        // Get the method with the specified name and parameters.
        var method = typeof(T).GetMethod("Parse", signature);
        // Initialize the parser delegate.
        return s => (T)method.Invoke(null, new[] { s });
    }
