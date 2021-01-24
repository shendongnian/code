    interface IFoo
    {
    }
    interface IFoo<in T> : IFoo
    {
    }
    class FooCollection 
    {
      List<IFoo> _items;
      public FooCollection(List<IFoo> items)
      {
        _items = items;
      }
    }
    var item1 = some instance of IFoo<int>;
    var item2 = some instance of IFoo<double>;
    var item3 = some instance of IFoo<string>;
    var list = new List<IFoo> { item1, item2, item3 };
    var col = new FooCollection(list);
