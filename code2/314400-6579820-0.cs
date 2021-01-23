    public class RegExSample
    {
          public static string AddBrackets(Match match)
          {
               return String.Format("[{0}]", match.Value);
          }
    }
