    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApp
    {
        public class Test
        {
            public static void Main()
            {
                var list = new List<string> { "johnsmith@mail.com", "john_newyork@mail.com", "john00@mail.com" };
                list.Sort(StringComparer.Ordinal);
                foreach (var element in list)
                {
                    Console.WriteLine(element);
                }
            }
        }
    }
