    public static IDictionary<string, string> FqnMap = new Dictionary<string, string>
    {
        { "Int", "System.Int32" },
        { "Double", "System.Double" },
        { "DateTime", "System.DateTime" },
    };
    public string GetFqn(string name)
    {
        return FqnMap[name]; // TODO: add error handling
    }
