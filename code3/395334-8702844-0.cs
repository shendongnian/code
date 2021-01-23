    using System;
    using System.Collections.Generic;
    
    public class Example
    {
        public static void Main()
        {
            List<int> table = new List<int>();
    
            table.Add(1);
            table.Add(2);
            table.Add(3);
            table.Add(4);
    
            foreach(int item in table)
            {
                Console.WriteLine(item);
            }
    
            table.Reverse();
    
            Console.WriteLine();
            foreach(int item in table)
            {
                Console.WriteLine(item);
            }
        }
    }
