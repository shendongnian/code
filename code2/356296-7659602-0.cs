    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    namespace ConsoleApplication1
    {
    class Program
    {
        static void TestOut(out int i)
        {
            i = 5;
            Thread.Sleep(5000);
        }
        static void Main(string[] args)
        {
            int i = 1;
            Console.WriteLine("i = " + i);
            Thread testOut = new Thread(new ThreadStart(() => TestOut(out i)));
            testOut.Start();
            Thread.Sleep(1000);
            Console.WriteLine("i = " + i);
            testOut.Join();
            Console.WriteLine("i = " + i);
            Console.WriteLine("Press ENTER to exit");
            Console.ReadLine();
        }
    }
    }
