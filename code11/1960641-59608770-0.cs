csharp
namespace Test
{
    internal static class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("Write the version numbers : ");
            var input = Console.ReadLine();
            var results = ParseInts(inpui.Split('-');
            foreach(var item in results)
            {
                Console.WriteLine(item);
            }
        }
        private static IEnumerable<int> ParseInts(IEnumerable<string> values, Func<string, int> parser)
        {
            foreach(var item in values)
            {
                yield return parser(item);
            }
        }
        private static int ParseInt(string value)
        => Convert.ToInt32(value);
    }
}
But simply we use this to get int values:
var input = Console.ReadLine();
var results = input.Split('-').Select(int.Parse);
instead of writing everything.
