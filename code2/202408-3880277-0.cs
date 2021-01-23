    using System;
    using System.Diagnostics;
    
    namespace AsyncConsoleRead
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process p = new Process();
                p.StartInfo.FileName = "findstr.exe";
                p.StartInfo.Arguments = "/lipsn foo *";
                p.StartInfo.WorkingDirectory = "C:\\";
                p.StartInfo.UseShellExecute = false;
    
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.RedirectStandardError = true;
                p.OutputDataReceived += new DataReceivedEventHandler(OnOutputDataReceived);
                p.ErrorDataReceived += new DataReceivedEventHandler(OnOutputDataReceived);
    
                p.Start();
    
                p.BeginOutputReadLine();
    
                p.WaitForExit();
            }
    
            static void OnOutputDataReceived(object sender, DataReceivedEventArgs e)
            {
                Console.WriteLine(e.Data);
            }
        }
    }
