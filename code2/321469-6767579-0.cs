    public class MyType // can be a struct. Depends on usage.
    {
      // should really use properties, I know, 
      // and these should probably not be static
      public static int a;
      public static string b;
      public static ushort c;
    }
    
    // elsewhere
    MyType[] myobj = new MyType[]{};
