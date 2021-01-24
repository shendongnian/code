using System.Collections.Generic;
using System.Linq;
namespace SplitExample
{
    public class Program
    {
        public static void Main()
        {
            var list = new List<double>()
            {
                10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20
            };
            var subLists = Split<double>(list, 3);
        }
        public static List<List<T>> Split<T>(List<T> source, int chunkSize)
        {
            return source
                .Select((x, i) => new { Index = i, Value = x })
                .GroupBy(x => x.Index / chunkSize)
                .Select(x => x.Select(v => v.Value).ToList())
                .ToList();
        }
    }
}
