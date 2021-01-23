    using System;
    using System.Diagnostics;
    
    class Program
    {
        static void Main(string[] args)
        {
            Process p = new Process();
            p.StartInfo.FileName = Environment.GetEnvironmentVariable("comspec");
            p.StartInfo.ErrorDialog = false;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            // Hook up async stdout and stderr reading
            p.ErrorDataReceived += ConsoleDataReceived;
            p.OutputDataReceived += ConsoleDataReceived;
            
            // Execute the process
            if (p.Start())
            {
                // Begin async stdout and stderr reading
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
    
                // Send the "Dir" command to the command line instance.
                p.StandardInput.WriteLine("dir");
    
                // Send "exit" and wait for exit
                p.StandardInput.WriteLine("exit");
                p.WaitForExit();
            } 
        }
    
        static void ConsoleDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
                Console.WriteLine(e.Data);
        }
    }
