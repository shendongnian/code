c#
using System;
using System.Collections.Generic;
using System.Linq;
namespace System.Collections.Generic
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<IEnumerable<T>> GroupWhile<T>(
            this IEnumerable<T> source, Func<T, bool> predicate)
        {
            using (var iterator = source.GetEnumerator())
            {
                List<T> currentList = null;
                while (iterator.MoveNext())
                {
                    if (predicate(iterator.Current))
                    {
                        if (currentList == null)
                        {
                            currentList = new List<T>() { iterator.Current };
                        }
                        else
                        {
                            currentList.Add(iterator.Current);
                        }
                    }
                    else
                    {
                        if (currentList != null)
                        {
                            yield return currentList;
                            currentList = null;
                        }
                    }
                }
                if (currentList != null)
                {
                    yield return currentList;
                }
            }
        }
    }
}
namespace StackOverflow
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var values = new[] {
                13, 18, 13, 12, 13, 17, 17, 18, 19, 20, 18,
                17, 17, 12, 13, 15, 17, 16, 16, 19, 18, 19,
                20, 19, 18, 16, 11, 13, 19, 14, 12
            };
            var sums = values
                .AsEnumerable()
                .GroupWhile(item => item >= 17)
                .Select(range => range.ToArray())
                .Where(array => array.Length > 1)
                .Select(array => array.Sum());
            foreach (var sum in sums)
            {
                Console.WriteLine("Sum = {0}", sum);
            }
        }
    }
}
Which outputs:
txt
Sum = 143
Sum = 113
