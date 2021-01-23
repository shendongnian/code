    public int UniqueValue(params string[] strings)
    {
        return String.Join("~", strings.AsEnumerable<string>()
                                       .OrderBy<string, string>(s => s)
                                       .ToArray<string>())
                     .GetHashCode();
    }
