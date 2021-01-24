    public interface IB<T>
    {
      void Foo(T parameter);
    }
    public class B<T> : IB<T>
    {
      public void Foo(T parameter)
      {
        var param = parameter;
        //...
      }
    }
    public class A<T>
    {
      private IEnumerable<IB<T>> collectionOfBs;
      public A(IEnumerable<IB<T>> collectionOfBs)
      {
      }
      public void foo(IEnumerable<T> param)
      {
        for ( int i = 0; i < collectionOfBs.Count(); i++ )
        {
          collectionOfBs.ElementAt(i).Foo(param.ElementAt(i));
        }
      }
    }
