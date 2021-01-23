    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Console.WriteLine("Verbatim list");
                List<string> list = new List<String> { "A","B","C","D" };
    
                foreach (var item in list)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine("Filtered list");
                int itemToSkip = 2;
                foreach (var item in list.Where((item, index) => index != itemToSkip))
                {
                    Console.WriteLine(item.ToString());
                }
                Console.ReadKey();
            }
        }
    }
