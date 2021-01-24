    using System;
    using System.Diagnostics;
    
    namespace ConsoleApp15
    {
        class Program
        {
            static void Main(string[] args)
            {
                var filePath = @"C:\Users\jjjjjjjjjjjj\Downloads\libwebp-1.0.3-windows-x86\bin\cwebp.exe";
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = filePath;
                startInfo.Arguments = "file.jpeg -o file.webp";
                startInfo.CreateNoWindow = true; // I've read some articles this is required for launching exe in Web environment
                startInfo.UseShellExecute = false;
                try
                {
                    using (Process exeProcess = Process.Start(startInfo))
                    {
                        exeProcess.WaitForExit();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadLine();
                }
            }
        }
    }
