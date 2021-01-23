    using System;
    
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    
    namespace ConsoleApplication1
    {
    class Program
    {
        private string threadVariable;
    
        static void Main(string[] args)
        {
            Console.WriteLine("Taking data from Main Thread\n->");
            string message = Console.ReadLine();
    
            threadVariable = "stuff";
    
            Thread myThread = new Thread(Write);
            Thread.IsBackground = true;
            Thread.Start();
        }
    
        public static void Write()
        {
            Console.WriteLine(stuff);
            Console.Read();
        }
    }
    }
