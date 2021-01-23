    public static IEnumerable<string> GetColumns()
    {
       string s = null;
       for (char c2 = 'A'; c2 <= 'Z' + 1; c2++)
       {
          for (char c = 'A'; c <= 'Z'; c++)
          {
             yield return s + c;
          }
          s = c2.ToString ();
       }
    }
