    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    namespace ProcessSample
    {
        class ClsProcess
        {
            void OpenProcessWithArguments()
            {
                Process.Start("IExplore.exe", "www.google.com");
            }
    
            void OpenProcessWithStartInfo()
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe");
                startInfo.WindowStyle = ProcessWindowStyle.Minimized;
    
                Process.Start(startInfo);
    
                startInfo.Arguments = "www.google.com";
    
                Process.Start(startInfo);
            }
    
            static void Main()
            {
                ClsProcess myProcess = new ClsProcess();
    
                myProcess.OpenProcessWithArguments();
                myProcess.OpenProcessWithStartInfo();
            }
        }
    }
