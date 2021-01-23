    public static class StringExtension
    {
      public static string Repeat(this string str, int count)
      {
        string ret = "";
    
        for (var x = 0; x < count; x++)
        {
          ret += str;
        }
    
        return ret;
      }
    }
