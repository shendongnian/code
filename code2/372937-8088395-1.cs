    using System;
    using System.Text;
    using System.Diagnostics;
    
    public class Program
    {
        static void Main(string[] args)
        {
            int max = 1000000;
            for (int times = 0; times < 5; times++)
            {
                {
                    Console.WriteLine("\ntime: {0}", (times+1).ToString());
                    Stopwatch sw = Stopwatch.StartNew();
                    for (int i = 0; i < max; i++)
                    {
                        string msg = "Your total is ";
                        msg += "$500 ";
                        msg += DateTime.Now;
                    }
                    sw.Stop();
                    Console.WriteLine("String +\t: {0}ms", ((int)sw.ElapsedMilliseconds).ToString().PadLeft(6));
                }
    
                {
                    Stopwatch sw = Stopwatch.StartNew();
                    StringBuilder msg = new StringBuilder();
                    for (int j = 0; j < max; j++)
                    {
                        msg.Clear();
                        msg.Append("Your total is ");
                        msg.Append("$500 ");
                        msg.Append(DateTime.Now);
                    }
                    sw.Stop();
                    Console.WriteLine("StringBuilder\t: {0}ms", ((int)sw.ElapsedMilliseconds).ToString().PadLeft(6));
                }
            }
            Console.Read();
        }
    }
