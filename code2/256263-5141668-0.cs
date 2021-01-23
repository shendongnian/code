    class MyGenericClass<T> where T : ICompareable
    {
      List<T> data;
      public AddData(T value)
      {
         data.Add(value);
      }
      public RemoveData(T value)
      {
         data.Remove(value);
      }
    }
