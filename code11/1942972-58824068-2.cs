    using System.Text;
    public static string Repeat(string str, int count)
    {
      StringBuilder builder = new StringBuilder();
      foreach ( char c in str )
        builder.Append(c, count);
      return builder.ToString();
    }
