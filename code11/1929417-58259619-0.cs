`
using System.Linq;
namespace ConsoleApp
{
  static partial class Program
  {
    static void Main(string[] args)
    {
      Test();
      Console.WriteLine("");
      Console.WriteLine("End.");
      Console.ReadKey();
    }
    static void Test()
    {
      Console.WriteLine(Check("aaaaaaaa"));
      Console.WriteLine(Check("aaaaaAaa"));
      Console.WriteLine(Check("aa2aaaaa"));
      Console.WriteLine(Check("aa2aaAaa"));
      Console.WriteLine(Check("Aa2aaAaa"));
    }
    static public bool Check(string s)
    {
      return s != null
          && s.Length == 8
          && s.Any(c => char.IsDigit(c))
          && s.Count(c => char.IsUpper(c)) == 1;
    }
  }
}
`
The order of condition testing is for performance.
Output:
    False
    False
    False
    True
    False
