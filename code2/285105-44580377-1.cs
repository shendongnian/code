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
                _waitHandle.Reset();
                new Thread(Waiter).Start();
                Thread.Sleep(2000);
                _waitHandle.Set();
                Console.ReadKey();
            }
    
            private static void Waiter()
            {
                Console.WriteLine("I'm Waiting...");
                _waitHandle.WaitOne();
                //The word will wait 2 seconds for printing
                Console.WriteLine("pass");
            }
        }
    }
