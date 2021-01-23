    public static class DynamicActionExtensions
    {
         public static void DynamicInvoke<T>(this T actual)
         {
              dynamic obj = actual;
              obj.SomeProperty = 123;
         }
    }
