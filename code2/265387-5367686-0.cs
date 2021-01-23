    using System;
    using System.Diagnostics;
    namespace InteractWithConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                ProcessStartInfo cmdStartInfo = new ProcessStartInfo();
                cmdStartInfo.FileName = @"C:\Windows\System32\cmd.exe";
                cmdStartInfo.RedirectStandardOutput = true;
                cmdStartInfo.RedirectStandardError = true;
                cmdStartInfo.RedirectStandardInput = true;
                cmdStartInfo.UseShellExecute = false;
                cmdStartInfo.CreateNoWindow = true;
                Process cmdProcess = new Process();
                cmdProcess.StartInfo = cmdStartInfo;
                cmdProcess.ErrorDataReceived += cmd_Error;
                cmdProcess.OutputDataReceived += cmd_DataReceived;
                cmdProcess.EnableRaisingEvents = true;
                cmdProcess.Start();
                cmdProcess.BeginOutputReadLine();
                cmdProcess.BeginErrorReadLine();
                cmdProcess.StandardInput.WriteLine("ping www.bing.com");     //Execute ping bing.com
                cmdProcess.StandardInput.WriteLine("exit");                  //Execute exit.
                cmdProcess.WaitForExit();
            }
            static void cmd_DataReceived(object sender, DataReceivedEventArgs e)
            {
                Console.WriteLine("Output from other process");
                Console.WriteLine(e.Data);
            }
            static void cmd_Error(object sender, DataReceivedEventArgs e)
            {
                Console.WriteLine("Output from other process");
                Console.WriteLine(e.Data);
            }
        }
    }
