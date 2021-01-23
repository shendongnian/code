    using System;
    using System.Threading;
    using System.Diagnostics;
    
    namespace MyParentProcess
    {
        class Program
        {
            static void Main(string[] args)
            {
                EventWaitHandle ewh = null;
                try
                {
                    ewh = new EventWaitHandle(false, EventResetMode.AutoReset, "CHILD_PROCESS_READY");
    
                    Process process = Process.Start("MyChildProcess.exe", Process.GetCurrentProcess().Id.ToString());
                    if (process != null)
                    {
                        if (ewh.WaitOne(10000))
                        {
                            // Child process is ready.
                        }
                    }
                }
                catch(Exception exception)
                { }
                finally
                {
                    if (ewh != null)
                        ewh.Close();
                }
            }
        }
    }
