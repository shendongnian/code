    public class Program {
        public static void Main()
        {
          String xs = "aBc";
          var x= xs.ReplaceInBetween('a', 'c', 'B', 'b');      }
      }
    
      public static class Extensions {
        public static string ReplaceInBetween(this String str,  char start, char end, char middle, char replacewith)
        {
           Regex x = new Regex($"([{start}])({middle})([{end}])");
          str=  x.Replace(str, "$1" + replacewith + "$3");
          return str;
        }
      }
