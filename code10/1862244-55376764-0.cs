    using System;
    using System.Diagnostics;
    using System.Threading;
    namespace ConsoleApp
    {
        public class Program
        {
            public static void Main(params string[] args)
            {
                PerformanceCounter c = new PerformanceCounter("Thermal Zone Information", "Temperature",@"\_TZ.TZ01");
                string a = "";
                while(a!="quit")
                {
                    Console.WriteLine(c.NextValue());
                    Thread.Sleep(500);
                }
            }
        }
    }
