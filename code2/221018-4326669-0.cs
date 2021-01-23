    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    static class Program
    {
        static IEnumerable<T> Prepend<T>(T first, IEnumerable<T> rest)
        {
            yield return first;
            foreach (var item in rest)
                yield return item;
        }
    
        static IEnumerable<IEnumerable<int>> M(int p, int t1, int t2)
        {
            if (p == 0)
                yield return Enumerable.Empty<int>();
            else
                for (int first = t1; first <= t2; ++first)
                    foreach (var rest in M(p - 1, first, t2))
                        yield return Prepend(first, rest);
        }
    
        static string Dump<T>(IEnumerable<T> items)
        {
            string s = "";
            bool first = true;
            foreach (var item in items)
            {
                if (!first)
                    s += ", ";
                first = false;
                s += item.ToString();
            }
            return s;
        }
    
        public static void Main()
        {
            foreach (var sequence in M(4, 0, 2))
                Console.WriteLine(Dump(sequence));
        }
    }
