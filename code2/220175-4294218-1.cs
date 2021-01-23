    using System;
    using System.Linq;
    
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();
    
            var values = input.Split(' ')
                .Select(int.Parse);
        }
    }
