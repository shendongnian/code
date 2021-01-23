    using System;
    using System.Diagnostics;
    using System.ComponentModel;
    namespace MyProcess
    {
        class MyProcess
        {
            public static void Main()
            {
               string CmdPath, CmdArgument, FrameworkPath;
               CmdPath = "cmd.exe";
               CmdArgument = "";
               FrameworkPath = "C:\\";
               ProcessStartInfo CmdLine = new ProcessStartInfo(CmdPath, CmdArgument);
               CmdLine.WindowStyle = ProcessWindowStyle.Maximized;
               CmdLine.WorkingDirectory = FrameworkPath;
               CmdLine.UseShellExecute = false;
               Process CmdProcess = new Process();
               CmdProcess.StartInfo = CmdLine;
               try
               {
                  CmdProcess.Start(); 
               }
               catch (Exception e)
               {
                   Console.WriteLine(e.Message);
               }
            }
        }
    }
