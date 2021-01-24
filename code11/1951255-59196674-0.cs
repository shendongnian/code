    public interface IParser
    {
        List<object> Parse();
        bool SupportsParsing(string key);
    }
    public class EventHandler : IHandler
    {
        private readonly IParser _parser;
        public EventHandler(IParser parser)
        {
            _parser = parser;
        }
        public void Handle()
        { }
    }
    public class EventHandlerFactory
    {
        private readonly IEnumerable<IParser> _parsers;
        public EventHandlerFactory(IEnumerable<IParser> parsers)
        {
            _parsers = parsers;
        }
        public IHandler Create(string key)
        {
            foreach (var parser in _parsers)
            {
                if (parser.SupportsParsing(key))
                {
                    return new EventHandler(parser);
                }
            }
            throw new NotImplementedException();
        }
    }
