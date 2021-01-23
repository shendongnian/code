    public static IEnumerable<T> ParseInput<T>(string input, IParser<T> parser)
    {
        var xml = XElement.Parse(input);
        // some more code here
        return parser.Parse(xml);
    }
