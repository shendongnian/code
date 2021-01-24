    static public class StringHelper
    {
      static public string RepeatEachChar(this string str, int count)
      {
        StringBuilder builder = new StringBuilder();
        for ( int index = 0; index < str.Length; index++ )
          builder.Append(str[index], count);
        return builder.ToString();
      }
    }
    Console.WriteLine("Back".RepeatEachChar(3));
