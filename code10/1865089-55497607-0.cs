    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication107
    {
        class Program
        {
            static void Main(string[] args)
            {
                 var myList = new List<Item>
                {
                    new Item { Name = "A70", Weight = 70},
                    new Item { Name = "B20", Weight = 90},
                    new Item { Name = "C10", Weight = 100},
                };
                var stats = new Dictionary<string, int>();
                myList.ForEach(x => stats.Add(x.Name, 0));
                var rnd = new Random();
                for (var i = 0; i < 1000000; ++i)
                {
                    var newList = GetSorted(myList, rnd);
                    ++stats[newList.Name];
                }
                var sum = stats.ToList().Sum(x => x.Value);
                stats.ToList().ForEach(x => Console.WriteLine("{0}: '{1}", x.Key, ((float)x.Value / sum * 100)));
                Console.ReadLine();
            }
            private static Item GetSorted(List<Item> list, Random rnd)
            {
                Item results = null;
                int value = rnd.Next(0,100);
                for(int i = 0; i < list.Count(); i++)
                {
                    if (value < list[i].Weight)
                    {
                        results = list[i];
                        break;
                    }
                }
                return results;
            }
        }
     
        class Item
        {
            public string Name { get; set; }
            public int Weight { get; set; }
        }
    }
