    class IFooCollection<T>
    {
      List<IFoo<T>> _items;
      public IFooCollection(List<IFoo<T>> items)
      {
        _items = items;
      }
    }
