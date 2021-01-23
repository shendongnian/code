    using System;
    using System.Collections.Generic;
    static class Extensions
    {
        public static double DoubleAverage(this IEnumerable<int> sequence)
        {
            double sum = 0.0;
            long count = 0;
            foreach(int item in sequence) 
            {
                ++count;
                sum += item;
            }
            return sum / count;
        }
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> seq1, IEnumerable<T> seq2)
        {
            foreach(T item in seq1) yield return item;
            foreach(T item in seq2) yield return item;
        }
    }
    
    
    class P
    {
        public static IEnumerable<int> Repeat(int x, long count)
        {
            for (long i = 0; i < count; ++i) yield return x;
        }
    
        public static void Main()
        {
            System.Console.WriteLine(Repeat(1000000000, 10000000).Concat(Repeat(1, 90000000)).DoubleAverage()); 
            System.Console.WriteLine(Repeat(1, 90000000).Concat(Repeat(1000000000, 10000000)).DoubleAverage()); 
        }
    }
