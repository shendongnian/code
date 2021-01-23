    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Diagnostics;
    
    namespace XPGameRemoval
    {
        static class Program
        {
            /// <summary>
            /// The main entry point for the application.
            /// </summary>
            [STAThread]
            static void Main()
            {
                string WinDir = Environment.GetEnvironmentVariable("WinDir");
                FileStream cStream = new FileStream(
                    WinDir + "\\Temp\\SysOC.txt", 
                    FileMode.Create, 
                    FileAccess.ReadWrite, 
                    FileShare.ReadWrite);
                StreamWriter cWriter = new StreamWriter(cStream);
                cWriter.WriteLine("[Components]");
                cWriter.WriteLine("pinball = off");
                cWriter.WriteLine("Solitaire = off");
                cWriter.WriteLine("freecell = off");
                cWriter.WriteLine("hearts = off");
                cWriter.WriteLine("minesweeper = off");
                cWriter.WriteLine("spider = off");
                cWriter.WriteLine("zonegames = off");
                cWriter.Close();
                cStream.Close();
                Process P = Process.Start(WinDir+"\\System32\\SysOCMgr.exe","/i:\""+WinDir+"\\Inf\\SysOC.Inf\" /u:\""+WinDir+"\\Temp\\SysOC.txt\" /q /r");
                int Timeout = 15;
                System.Threading.Thread.Sleep(5000);
                while (File.Exists(WinDir+"\\System32\\SOL.EXE") && Timeout>0 && !P.HasExited)
                {
                    System.Threading.Thread.Sleep(59000);  // wait a little under 15 minutes
                    Timeout--;
                }
                if (!P.HasExited)
                    P.Kill();
                if (P.ExitCode != 0) // SysOCMgr errored out, return error
                    Environment.Exit(P.ExitCode);
                if (File.Exists(WinDir + "\\System32\\SOL.EXE")) // something went wrong, return generic error...
                    Environment.Exit(80);
            }
        }
    }
