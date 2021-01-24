`
using System.Linq;
namespace ConsoleApp
{
  static partial class Program
  {
`
`
    static void Main(string[] args)
    {
      Test();
      Console.WriteLine();
      Console.WriteLine("End.");
      Console.ReadKey();
    }
`
`
    static void Test()
    {
      Console.WriteLine(Check("aaaaaaaa"));
      Console.WriteLine(Check("aaaaaAaa"));
      Console.WriteLine(Check("aa2aaaaa"));
      Console.WriteLine(Check("aa2aaAaa"));
      Console.WriteLine(Check("aa2aaÄa8"));
      Console.WriteLine(Check("Äa2aaAaa"));
      Console.WriteLine(Check("Äa2aaAa8"));
    }
`
`
    static public bool Check(string str)
    {
      return str != null
          && str.Length == 8
          && str.Any(c => char.IsDigit(c))
          && str.Count(c => char.IsUpper(c)) == 1;
    }
`
`
  }
}
`
The order of condition testing is for performance.
Output:
`
False
False
False
True
True
False
False
`
