    public static class ExtensionMethods {
    
       public static double ToDouble<T>(this T value) where T : struct {
          return Convert.ToDouble(value);
       }
    }
