    public class GenericClass : IGenericClass
    {
      public IQueryable<T> GenericMethod1<T>() where T:class
      public IEnumerable<T> GenericMethod2<T>() where T:class
      public object NonGenericMethod1(object t)
    }
