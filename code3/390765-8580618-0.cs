    // takes any IEnumerable, not just strings (like an int array for example)
    public static string Join(this IEnumerable source, string delimiter = ", ")
    {
       return string.Join(
                delimiter, 
                source.OfType<object>()
                .Select(i => i == null ? "null" : i.ToString()).ToArray()
               )
    }
