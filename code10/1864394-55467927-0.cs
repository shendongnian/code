    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp5
    {
        class Program
        {
            static void Main(string[] args)
            {
                var myList = new List<List<double>>();
    
                myList.Add(new List<double> { 1, 3, 6, 8 });
                myList.Add(new List<double> { 1, 2, 3, 4 });
                myList.Add(new List<double> { 1, 4, 8, 12 });
    
                var averageFirst= myList.Select(z => z.First()).Average();
                var averageLast = myList.Select(z => z.Last()).Average();
    
                Console.WriteLine(averageFirst);
                Console.WriteLine(averageLast);
    
                Console.ReadLine();
            }
        }
    }
