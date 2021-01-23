    using System;
    using System.Threading;
    namespace ThreadingInCSharp.Signaling
    {
        class Program
        {
            static EventWaitHandle _waitHandle = new AutoResetEvent(false);
            static void Main(string[] args)
            {
                //The event's state is Signal
                _waitHandle.Set();
                new Thread(Waiter).Start();
                Thread.Sleep(2000);
                _waitHandle.Set();
                Console.ReadKey();
            }
            private static void Waiter()
            {
                Console.WriteLine("I'm Waiting...");
                _waitHandle.WaitOne();
                //The word pass will print immediately 
                Console.WriteLine("pass");
            }
        }
    }
