    static public class StringHelper
    {
      static public string RepeatEachChar(this string str, int count)
      {
        StringBuilder builder = new StringBuilder();
        foreach ( char c in str )
          builder.Append(c, count);
        return builder.ToString();
      }
    }
    Console.WriteLine("Back".RepeatEachChar(3));
