    using System.Reflection;
    public class Foo
    {
      public static void Bar()
      {
        Type type = MethodBase.GetCurrentMethod().DeclaringType();
      }
    }
