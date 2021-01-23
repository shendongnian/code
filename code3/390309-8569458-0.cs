    using System;
    using System.Diagnostics;
    
    class Tick {
      static void Main(string[] args) {  
        Process p = new Process();
    
        p.StartInfo.UseShellExecute = false;
        p.StartInfo.RedirectStandardOutput = false;
        p.StartInfo.RedirectStandardInput = true;
        p.StartInfo.RedirectStandardError = true;
        p.StartInfo.WorkingDirectory = Environment.CurrentDirectory;
        p.StartInfo.FileName = "/bin/sh";
        p.StartInfo.Arguments = "test.sh";
        
        p.EnableRaisingEvents = true;
        p.ErrorDataReceived += new DataReceivedEventHandle(ShellProc_ErrorDataReceived);
    
        p.Start();
        System.Threading.Thread.Sleep (5000);
        Console.WriteLine ("done");
      }  
      static void ShellProc_ErrorDataReceived (object sender, DataReceivedEventArgs ea)
      {
      }
    }
