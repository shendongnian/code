    public static class StringExtension
    {
      public static string Repeat(this string str, int count)
      {
        if (count == 0)
          return "";
    
        return string.Concat(Enumerable.Repeat(indent, N))
      }
    }
