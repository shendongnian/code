     public static class StringExtensions
     {
         public static string Collapse( this string source )
         {
              if (string.IsNullOrWhiteSpace( source ))
              {
                  return string.Empty;
              }
              var builder = new StringBuilder();
              foreach (char c in source)
              {
                  if (!char.IsWhiteSpace( c ))
                  {
                      builder.Append( c );
                  }
              }
              return builder.ToString();
         }
    }
