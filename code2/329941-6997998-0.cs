    public static class MyStringExtensions
    {
      public static string SafeRemove(this string s, int numCharactersToRemove)
      {
        if (numCharactersToRemove > s.Length)
        {
          throw new ArgumentException("numCharactersToRemove");
        }
    
        // other validation here
    
        return s.Remove(s.Length - numCharactersToRemove);
      }
    }
    
    var s = "123456";
    var r = s.SafeRemove(3); //r = "123"
    var t = s.SafeRemove(7); //throws ArgumentException
