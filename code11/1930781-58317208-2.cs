    public interface IB
    {
      void Foo<TParam>(TParam parameter);
    }
    public class B<T> : IB
    {
      public void Foo<TParam>(TParam parameter)
      {
        var param = parameter;
        Console.WriteLine("param type: " + param.GetType().Name);
      }
    }
    public class A
    {
      private IEnumerable<IB> CollectionOfBs;
      public A(IEnumerable<IB> collectionOfBs)
      {
        CollectionOfBs = collectionOfBs;
      }
      public void Foo(IEnumerable<object> param)
      {
        for ( int i = 0; i < CollectionOfBs.Count(); i++ )
        {
          CollectionOfBs.ElementAt(i).Foo(param.ElementAt(i));
        }
      }
    }
*Test method:*
    static void Test()
    {
      var listInstances = new List<IB> { new B<int>(), new B<double>(), new B<string>() };
      var container = new A(listInstances);
      var listParams = new List<object> { 2, 4.3, "test" };
      container.Foo(listParams);
    }
*Output:*
    param type: Int32
    param type: Double
    param type: String
