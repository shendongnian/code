    public static IEnumerable<T> ParseInput<T>(string input, IObjectResolver resolver)
    {
        var xml = XElement.Parse(input);
        // some more code here
        var parser = resolver.Resolve<IParser<T>>();
        return parser.Parse(xml);
    }
