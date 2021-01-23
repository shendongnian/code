    using System;
    using System.Diagnostics;
    
    class Program
    {
        static void Main(string[] args)
        {
            Process myProc = new Process();
            myProc.StartInfo.WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
            myProc.StartInfo.FileName = "run.bat";
            myProc.Start();
        }
    }
