    using System;
    using System.Threading;
    
    namespace qqq
    {
        class Program
        {
            public static void DoAsync(Action<int> whenDone)
            {
                new Thread(o => { Thread.Sleep(3000); whenDone(42); }).Start();
            }
    
            static public int Do()
            {
                var mre = new ManualResetEvent(false);
    
                int retval = 0;
                DoAsync(i => { retval = i; mre.Set(); });
    
                if (mre.WaitOne())
                    return retval;
                throw new ApplicationException("Unexpected error");
            }
    
            static void Main(string[] args)
            {
                Console.WriteLine(Do());
            }
        }
    }
