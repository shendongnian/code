    using System;
    using System.Threading;
    namespace SO6304593
    {    
        class Program
        {
            static void Main(string[] args)
            {
                 Console.WriteLine("yaya instant");
                Thread t1 = new Thread(delegate(object x) { Thread.Sleep((int)x); Console.WriteLine("Hello 1");});
                Thread t2 = new Thread(x => {Thread.Sleep((int)x); Console.WriteLine("Hello 2");});
                t1.Start(5000);
                t2.Start(3000);
                t1.Join();
                t2.Join();
            }
        }
    }
