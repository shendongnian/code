    using System;
    using System.Threading;
    
    namespace Test_Console
    {
        class Program
        {
            static EventWaitHandle EWHandle;
    
            static void Main(string[] args)
            {
                EWHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
                Thread WorkThread = new Thread(new ThreadStart(DoStuff));
                EWHandle.WaitOne();
            }
    
            static void DoStuff()
            {
                Console.WriteLine("Do what you want here");
                EWHandle.Set();
            }
        }
    }
