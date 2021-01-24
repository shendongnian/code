    using log4net;
    using System;
    using System.Diagnostics;
    namespace ConsoleApplication1
    {
        class Program
        {
            private static long num;
            private static readonly ILog log = LogManager.GetLogger
                  (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            static void Main(string[] args)
            {
                ...
                Console.WriteLine("Loop ran for {0}ms", sw.ElapsedMilliseconds);
                log.Info(string.Format("Input: {0} - Time: {1}ms", num, sw.ElapsedMilliseconds)); 
                ...
            }
        }
    }
