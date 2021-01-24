    public class MyCreator : ICreator
    {
      private readonly IInjectedDependencyFactory _factory;
    
      public MyCreator(IInjectedDependencyFactory factory)
      {
        _factory = factory;
      }
    
      public List<MappedObjects> Map()
      { 
         return ObjectToMap.Select(otm => new MappedObject(otm, _factory.Create())).ToList();
      }
    }
