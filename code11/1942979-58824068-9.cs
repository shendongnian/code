    static public class StringHelper
    {
      static public string RepeatEachChar(this string str, int count)
      {
        StringBuilder builder = new StringBuilder(str.Length*count);
        foreach ( char c in str )
          builder.Append(c, count);
        return builder.ToString();
      }
    }
    Console.WriteLine("Back".RepeatEachChar(3));
