    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.Write("Type a number : ");
                int.TryParse(Console.ReadLine(), out int searchItem);
                List<int> items = new List<int>() { 1, 2, 3, 1 };
                
                //Determine if the item is in the list.
                Console.WriteLine($"{searchItem} {(items.Contains(searchItem) ? "is" : "isn't")} in the list");
                Console.WriteLine($"{searchItem} {(items.Where(item => item == searchItem).Any() ? "is" : "isn't")} in the list");
                Console.WriteLine($"{searchItem} {(items.Where(item => item == searchItem).Count() > 0 ? "is" : "isn't")} in the list");
                
                //Determine number of ocurrences
                Console.WriteLine($"{searchItem} is found {items.Where(item => item == searchItem).Count()} times in the list");
    
                Console.ReadLine();
            }
        }
    }
