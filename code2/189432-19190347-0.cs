    public class Test<T> where T : class
    {
      public Test()
      {
        Type t = typeof( T );
        if( !t.IsInterface )
          throw new ArgumentException( "T must be an interface type" );
      }
    }
