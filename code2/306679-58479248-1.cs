    using System;
    using System.Threading;
    using System.Diagnostics;
    
    namespace MyChildProcess
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    // Representing some time consuming work.
                    Thread.Sleep(5000);
    
                    EventWaitHandle.OpenExisting("CHILD_PROCESS_READY")
                        .Set();
    
                    Process.GetProcessById(Convert.ToInt32(args[0]))
                        .WaitForExit();
                }
                catch (Exception exception)
                { }
            }
        }
    }
