    public static class StringExtensions
    {
          public static bool Contains(this string input, params string[] queries)
          {
               foreach (string s in queries)
               {
                    if (!input.Contains(s)) return false;
               }
               return true;
          }
    }
