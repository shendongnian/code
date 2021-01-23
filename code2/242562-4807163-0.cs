    public class ClassC : IClassC
    {
      private readonly Func<string, IFooBuilder> _builderFactory;
    
      public ClassC(Func<string, IFooBuilder> builderFactory)
      {
        _builderFactory = builderFactory;
      }
    
      public ResultObject BuildMyFoo(InitialObject bar)
      {
        IFooBuilder builder = _builderFactory(bar.Name);
        return builder.build(bar);
      }
    }
