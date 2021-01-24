    public static class StringExtensions
    {
       public static string[] Split(this string source, string value, StringSplitOptions options = StringSplitOptions.None)
       {
          return source?.Split(new[] { value }, options);
       }
    
       public static string[] Split(this string source, params string[] values)
       {
          return source?.Split(values, StringSplitOptions.None);
       }
    }
    ...
    
    // usage
    var someString = "string";
    someString.Split(",");
    someString.Split(",",".");
    someString.Split(",", StringSplitOptions.RemoveEmptyEntries);
