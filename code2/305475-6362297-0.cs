    class Program
        {
        static void Main(string[] args)
        {
          Console.WriteLine(ExtractNumbers("( 01 - ABCDEFG )"));    // 01
          Console.ReadLine();
        }
 
        static string ExtractNumbers(string expr)
        {
            return string.Join(null, System.Text.RegularExpressions.Regex.Split(expr, "[^\\d]"));
        }
    }
