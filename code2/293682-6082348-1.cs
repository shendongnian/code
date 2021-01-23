    public class MyClass
    {
      public IEnumerable<TypeA> TypeAs{get{_lstTypeA.Select(x=>x)}};
      public IEnumerable<TypeB> TypeBs{get{_lstTypeB.Select(x=>x)}};
    }
