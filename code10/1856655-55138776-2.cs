    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp5
    {
        class Program
        {
            public class Items
            {
                public string ItemID { get; set; }
                public int QuantitySold { get; set; }
            }
    
            static void Main(string[] args)
            {
                // Sample data
                var oldList = new List<Items>();
                oldList.AddRange(Enumerable.Range(0, 20000).Select(z => new Items() { ItemID = z.ToString(), QuantitySold = 4 }));
    
                var newList = new List<Items>();
                newList.AddRange(Enumerable.Range(0, 20000).Select(z => new Items() { ItemID = z.ToString(), QuantitySold = 5 }));
    
                var results = oldList.Join(newList,
                                                left => left.ItemID,
                                                right => right.ItemID,
                                                (left, right) => new { left, right })
                                    .Where(z => z.left.QuantitySold != z.right.QuantitySold).Select(z => z.left);
    
                Console.WriteLine(results.Count());
                Console.ReadLine();
            }
        }
    }
