    public static IEnumerable<T> ParseInput<T>(string input)
    {
        var parser = Container.Current.Resolve<IXmlParser>();
        return parser.ParseInput(input);
    }
    public class XmlParser : IXmlParser
    {
      private readonly IObjectResolver _resolver;
      public XmlParser(IObjectResolver resolver)
      {
         _resolver = resolver
      }
      public IEnumerable<T> ParseInput<T>(string input)
      {
          var xml = XElement.Parse(input);
          // some more code here
          var parser = _resolver.Resolve<IParser<T>>();
          return parser.Parse(xml);
      }
    }
