    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            ShowDivisibleBy3(new List<int> { 1, 3, 6, 7, 9 });
            ShowDivisibleBy3(new List<decimal> { 1.5m, 3.3m, 6.0m, 7m, 9.00m });
        }
        
        static void ShowDivisibleBy3<T>(IEnumerable<T> source)
        {
            foreach (dynamic item in source)
            {
                if (item % 3 == 0)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
