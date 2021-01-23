    MySecondParamsFunction(items.Append("test string", 31415));
    // ...
   
    public static class ArrayExtensions {
      public static T[] Append<T>(this T[] self, params T[] items) {
        return self.Concat(items).ToArray();
      }
    }
