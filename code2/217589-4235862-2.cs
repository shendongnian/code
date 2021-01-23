    using System;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch sw = new Stopwatch();
    
                int max = 100000000;
    
                sw.Start();
                for (int i = 0; i < max; i++)
                    IncrementMinute1(0, -61);
                sw.Stop();
    
                Console.WriteLine("IncrementMinute1: {0} ms", sw.ElapsedMilliseconds);
                
                sw.Reset();
    
                sw.Start();
                for (int i = 0; i < max; i++)
                    IncrementMinute2(0, -61);
                sw.Stop();
    
                Console.WriteLine("IncrementMinute2: {0} ms", sw.ElapsedMilliseconds);
    
                Console.ReadLine();
            }
    
            static void IncrementMinute1(int min, int incr)
            {
                int hourIncrement = incr / 60;
                int minIncrement = incr % 60;
    
                int newMin = min + minIncrement;
    
                if (newMin < 0)
                {
                    newMin += 60;
                    hourIncrement--;
                }
                else if (newMin > 60)
                {
                    newMin -= 60;
                    hourIncrement++;
                }
            }
    
            static void IncrementMinute2(int min, int incr)
            {
                min += incr;
                int hourIncrement = (int)Math.Floor(min / 60.0);
                min -= hourIncrement * 60;
            }
        }
    }
