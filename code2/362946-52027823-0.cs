    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    namespace deadlocktest
    {
        class Program
        {
        static object object1 = new object();
        static object object2 = new object();
        public static void FunctionOne()
        {
            lock (object1)
            {
                Console.WriteLine("FunctionOne called 1");
                Thread.Sleep(1000);
                lock (object2)
                {
                    Console.WriteLine("FunctionOne called 2, never called");
                }
            }
        }
        public static void FunctionTwo()
        {
            lock (object2)
            {
                Console.WriteLine("FunctionTwo called 1");
                Thread.Sleep(1000);
                lock (object1)
                {
                    Console.WriteLine("FunctionTwo called 2, never called");
                }
            }
        }
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(FunctionOne);
            Thread thread2 = new Thread(FunctionTwo);
            thread1.Start();
            thread2.Start();
            int i = 0;
            while (i < 9)
            {
                Console.WriteLine("How bad thread!");
                i++;
            }
            thread1.Join();
            thread2.Join();
            Console.ReadLine();
        }
    }
}
