    public class Program {
        public static void Main()
        {
          var isBetween = "abc".IsBetween('b', 'a', 'c', out int i);
          Console.WriteLine(isBetween); //True
          Console.WriteLine(i); //True
        }
      }
    
      public static class Extensions {
        public static bool IsBetween(this String str, char middle, char start, char end, out int index)
        {
          index = - 1;
          var left = str.IndexOf(start);
          var right = str.IndexOf(end);
          index = str.IndexOf(start) + 1 == str.IndexOf(end) -1 ? str.IndexOf(end) - 1: -1 ;
          return str[index] == middle ;
          
        }
      }
