    public static IEnumerable<T> ParseInput(this IParser<T> parser, XElement input)
    {
        // some more code here
        return parser.Parse(input);
    }
    public static IEnumerable<T> ParseInput(this IParser<T> parser, string input)
    {
        return parser.ParseInput(XElement.Parse(input));
    }
