    using System;
    using System.Diagnostics;
    namespace Execute_test
    {
        class Program
        {
            static void Main(string[] args)
            {
    		Process proc = new System.Diagnostics.Process();
              ProcessStartInfo pi = new ProcessStartInfo("ls"){
    			ArgumentList = {"'","/tmp/","'"}
    		};
    		proc.StartInfo = pi;
              proc.Start();
              do { System.Threading.Thread.Sleep(50); } while (proc.HasExited == false);
              Environment.Exit(0);
            }
        }
    }
