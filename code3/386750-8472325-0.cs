    using System;
    using System.Diagnostics;
    
    namespace MySolution
    {
        class Program
        {
            static void Main(string[] args)
            {
                var sw = Stopwatch.StartNew();
                
                // code to be timed here
    
                sw.Stop();
                Console.WriteLine("Run time in ms = {0}", sw.Elapsed.TotalMilliseconds);
            }
        }
    }
