    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        public class Pair
        {
            public Pair(int first, int second)
            {
                this.First = first;
                this.Second = second;
            }
    
            public int First { get; set; }
            public int Second { get; set; }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                var pairs = new List<Pair>();
                pairs.Add(new Pair(100, 0));
                pairs.Add(new Pair(200, 0));
                pairs.Add(new Pair(0, 400));
    
                int currentTotal = 0;
                var runningTotals = pairs.Select(m => 
                { 
                    currentTotal = currentTotal + (m.First - m.Second);
    
                    return new
                    {
                        First = m.First,
                        Second = m.Second,
                        Total = currentTotal
                    };
                });
    
                foreach (var total in runningTotals)
                {
                    Console.Write(total.First);
                    Console.Write("\t\t");
                    Console.Write(total.Second);
                    Console.Write("\t\t");
                    Console.Write(total.Total);
                    Console.Write(Environment.NewLine);
                }
    
                Console.ReadLine();
            }
        }
    }
