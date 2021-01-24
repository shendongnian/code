    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp8
    {
        class Program
        {
            public class feed_fish
            {
                public string Pond_Name { get; set; }
                public int Total_feed_weight { get; set; }
                public override string ToString()
                {
                    return $"Name: {Pond_Name } Weight: {Total_feed_weight}";
                }
            }
            static void Main(string[] args)
            {
                List<feed_fish> list = new List<feed_fish>()
                {
                    new feed_fish{Pond_Name ="Pond 1", Total_feed_weight=56},
                    new feed_fish{Pond_Name ="Pond 2", Total_feed_weight=33},
                    new feed_fish{Pond_Name ="Pond 1", Total_feed_weight=45},
                    new feed_fish{Pond_Name ="Pond 2", Total_feed_weight=54},
                    new feed_fish{Pond_Name ="Pond 3", Total_feed_weight=100},
                    new feed_fish{Pond_Name ="Pond 3", Total_feed_weight=200}
                };
    
                List<feed_fish> gruppedList = list.GroupBy(r => r.Pond_Name, (key, enumerable) =>
                 {
                     return new feed_fish { Pond_Name = key, Total_feed_weight = enumerable.Sum(k => k.Total_feed_weight) };
                 }).OrderByDescending(t => t.Total_feed_weight).ToList();
    
                foreach (var item in gruppedList)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadKey();
            }
        }
    }
