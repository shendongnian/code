    using System;
    using System.Linq;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] a = { "abc", "xyz", "abc", "def", "ghi", "asdf", "ghi", "xd", "abc" };
                string[] b = a.Distinct().ToArray();
                foreach (string s in b)
                    Console.WriteLine(s);
                Console.ReadLine();
            }
        }
    }
