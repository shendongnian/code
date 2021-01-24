    using System;
    using System.Diagnostics;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sw = Stopwatch.StartNew();
    
                while (true)
                {
                    Console.WriteLine(sw.ElapsedMilliseconds);
                }
            }
        }
    }
