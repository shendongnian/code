    public class InputParser
    {
        private readonly IParserFactory _parserFactory;
        public InputParser(IParserFactory parserFactory)
        {
            _parserFactory = parserFactory;
        }
        public IEnumerable<T> ParseInput<T>(string input)
        {
            var xml = XElement.Parse(input);
            // some more code here
            var parser = _parserFactory.CreateParser<T>();
            return parser.Parse(xml);
        }
    }
