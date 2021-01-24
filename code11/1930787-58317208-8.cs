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
        if ( param.Count() < CollectionOfBs.Count() )
          throw new ArgumentException();
        for ( int i = 0; i < CollectionOfBs.Count(); i++ )
          CollectionOfBs.ElementAt(i).Foo(param.ElementAt(i));
      }
    }
*Test method*
    static void Test()
    {
      var listInstances = new List<IB> { new B<int>(), new B<double>(), new B<string>() };
      var container = new A(listInstances);
      var listParams = new List<object> { 2, 4.3, "test" };
      container.Foo(listParams);
    }
*Output*
    param type: Int32
    param type: Double
    param type: String
*Considerations*
The problem here is that any bad matching parameter type can be passed.
For example with the Test(), you can have a double instead of the first integer and it works: you get a Double on your Int32 instance...
    param type: Double
    param type: Double
    param type: String
Having the diamond operator `<>` you will be able to use a generic interface and parse on a closed constructed types list... and your design will have a better smell:
    public interface IB<T>
    {
      void Foo(T parameter);
    }
    public class B<T> : IB
    {
      public void Foo(T parameter)
      {
        var param = parameter;
        Console.WriteLine("param type: " + param.GetType().Name);
      }
    }
    public class A
    {
      private IEnumerable<IB<>> CollectionOfBs;
      public A(IEnumerable<IB<>> collectionOfBs)
      {
        CollectionOfBs = collectionOfBs;
      }
      public void Foo(IEnumerable<object> param)
      {
        if ( param.Count() < CollectionOfBs.Count() )
          throw new ArgumentException();
        for ( int i = 0; i < CollectionOfBs.Count(); i++ )
        {
          CollectionOfBs.ElementAt(i).Foo(param.ElementAt(i));
        }
      }
    }
Hence with that, any bad matching type parameter will raise an exception at runtime.
