    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    namespace StackQue
    {
        class Sample
        {
            public static void Main(string[] args)
            {
                Dictionary<string, decimal> items = new Dictionary<string, decimal>();
                for (var i = 0; i < 2; i++)
                {
                    Console.WriteLine("Write an item");
                    string item = Console.ReadLine();
                    Console.WriteLine("Write an price");
                    decimal price = Convert.ToDecimal(Console.ReadLine());
                    items.Add(item, price);
                }
                foreach (var item in items)
                {
                    Console.WriteLine("Item " + item.Key + " have price " + item.Value + ".");
                }
            }
        }
    }
