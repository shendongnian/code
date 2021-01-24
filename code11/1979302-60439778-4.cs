    using System;
    using System.Collections.Generic;
    using System.Linq;
    class Program
    {
        static void Main(string[] args)
        {
            int[] sampleArray = new int[] { 1, 2, 3, 2, 1, 3, 1, 2, 3 };
            var indices = getAllIndices(sampleArray, i => i == 2);
            var rnd = new Random();
            var i = rnd.Next(0, indices.Count());
            var randomIndex = indices.ElementAt(i);
            Console.WriteLine(randomIndex);
            Console.ReadLine();
        }
    
        static IEnumerable<int> getAllIndices(int[] array, Predicate<int> predicate)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (predicate(array[i]))
                    yield return i;
            }
        }
    }
