    public static IEnumerable<T> ParseInput<T>(string input)
    {
        var parser = Container.Current.Resolve<IXmlParser<T>>();
        return parser.ParseInput(input);
    }
    public class XmlParser : IXmlParser<T>
    {
      private readonly IParser<T> _parser;
      public XmlParser(IParser<T> parser)
      {
         _parser= parser;
      }
      public IEnumerable<T> ParseInput(string input)
      {
          var xml = XElement.Parse(input);
          // some more code here
          return _parser.Parse(xml);
      }
    }
