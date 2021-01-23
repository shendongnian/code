    public class SomeClass
    {
      private readonly Lazy<ISomeDependency> _lazyField;
    
      // Ctor
      public SomeClass(ISomeFactory factory)
      {
         _lazyField = new Lazy<ISomeDependency>(() => factory.Create());
      }
    }
