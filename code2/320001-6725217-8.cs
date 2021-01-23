    using System;
    using My.Extensions;
    namespace My.Program
    {
        static class Program
        {
            static void Main(string[] args)
            {
                string s = "Hello, World";
                string t = s.Truncate(5);
                Console.WriteLine(s);
                Console.WriteLine(t);
            }
        }
    }
