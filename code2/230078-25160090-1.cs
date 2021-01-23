    #if NOT_RUNNING_ON_4
    public static class GuidExtensions
    {
       public static bool TryParse(this string s, out Guid result)
       {
           if (s.IsNullOrEmpty())
               return null;
           try
           {
              return new Guid(s);
           }
           catch (FormatException)
           {
              return null;
          }
       }
    }
    #else
        #error switch parsing to .NET 4.0
    #endif
