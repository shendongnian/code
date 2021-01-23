    using System;
    
    class Program
    {
        static void Main(string[] args)
        {
            // usage program.exe page#
            // page# between 1 and 100
            int minPage = 1;
            int maxPage = 100;
            int currentPage = int.Parse(args[0]);
    
            // output nice pagination
            // always have a group of 5
    
            int minRange = Math.Max(minPage, currentPage-2);
            int maxRange = Math.Min(maxPage, currentPage+2);
    
            if (minRange != minPage)
            {
                Console.Write(minPage);
                Console.Write("...");
            }
    
            for (int i = minRange; i <= maxRange; i++)
            {
                Console.Write(i);
                if (i != maxRange) Console.Write(" ");
            }
    
            if (maxRange != maxPage)
            {
                Console.Write("...");
                Console.Write(maxPage);
            }
        }
    }
