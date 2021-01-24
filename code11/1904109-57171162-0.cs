    using System;
    using System.Diagnostics;
    using System.IO;
    
    namespace RunAsAdmin
    {
        class Program
        {
            static void Main(string[] args)
            {
                /*Note: Running a batch file (.bat) or similar script file as admin
                Requires starting the interpreter as admin and handing it the file as Parameter 
                See documentation of Interpreting Programm for details */
    
                //Just getting the Absolute Path for Notepad
                string windir = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                string FullPath = Path.Combine(windir, @"system32\notepad.exe");
    
                //The real work part
                ProcessStartInfo startInfo = new ProcessStartInfo(FullPath);
                startInfo.Verb = "runas";
                System.Diagnostics.Process.Start(startInfo);
            }
        }
    }
