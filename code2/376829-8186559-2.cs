    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class Program
    {
        public static void Main(String[] args)
        {
            int[] source = { 1, 2, 3, 4, 5, 6, 7 };
            
            var skeet = SkeetAnswer(source, 3);
            var fisher = FisherAnswer(source, 3);
    
            Console.WriteLine("Size of the first element of Skeet's solution:");
            Console.WriteLine(skeet.First().Count());
            Console.WriteLine(skeet.First().Count());
            Console.WriteLine(skeet.First().Count());
    
            Console.WriteLine("Size of the first element of Fisher's solution:");
            Console.WriteLine(fisher.First().Count());
            Console.WriteLine(fisher.First().Count());
            Console.WriteLine(fisher.First().Count());
        }
        
        static IEnumerable<IEnumerable<int>> SkeetAnswer(IEnumerable<int> source,
                                                         int size)
        {
            return source.Select((value, index) => new { value, index })
                         .GroupBy(pair => pair.index / size, pair => pair.value);
        }
        
        static IEnumerable<IEnumerable<int>> FisherAnswer(IEnumerable<int> source,
                                                          int size)
        {
            int index = 0;
            return source.GroupBy(x => (index++ / size));
        }
    }
