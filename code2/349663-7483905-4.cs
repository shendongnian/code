    public interface IParserFactory{
      IEnumerable<IParser> BuildParsers();
    }
    public class UnityParserFactory : IParserFactory {
      private IUnityContainer _container;
      public UnityParserFactory(IUnityContainer container){
        _container = container;
      }
      public IEnumerable<IParser> BuildParsers() {
        return _container.ResolveAll<IParser>();
      }
    }
    
    public class Crawler {
      public Crawler(IParserFactory parserFactory) {
         // init here...
      }
    }
