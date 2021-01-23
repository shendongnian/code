    using System;
    using System.Collections.Generic;
    public static class Extensions
    {
        public static void Dump<T>(this IEnumerable<T> items, string name)
        {
            Console.WriteLine(name);
            foreach (T item in items)
            {
                Console.Write(item);
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    class Test
    {    
        static void Main()
        {
            var ints = new List<int> { 5, 8, 2, 1, 7 };
            var mergeSortInt = new MergeSort<int>();
            var sortedInts = mergeSortInt.Sort(ints);
            sortedInts.Dump("Sorted");
        }
    }
