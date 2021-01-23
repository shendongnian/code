    public static class GenericClass
    {
      public static IQueryable<T> GenericMethod1<T>() where T:class
      public static IEnumerable<T> GenericMethod2<T>() where T:class
      public static object NonGenericMethod1(object t)
    }
