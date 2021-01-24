    using System.Text;
    public static string Repeat(string str, int count)
    {
      StringBuilder builder = new StringBuilder();
      for ( int index = 0; index < str.Length; index++ )
        builder.Append(str[index], count);
      return builder.ToString();
    }
