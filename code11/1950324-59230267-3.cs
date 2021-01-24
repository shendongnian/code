    using System;
    using System.Diagnostics;
    using System.Threading;
    
    
    namespace PyTest
    {
        class Program
        {
    
            static void Main(string[] args)
            {
                string workingDirectory = @"C:\Test";
                var process = new Process
                {                
                    StartInfo = new ProcessStartInfo
                    {
                        FileName = "cmd.exe",
                        RedirectStandardInput = true,
                        UseShellExecute = false,
                        RedirectStandardOutput = true,
                        WorkingDirectory = workingDirectory
                    }
                
                };
                process.Start();
                
    
                using (var sw = process.StandardInput)
                {
                    if (sw.BaseStream.CanWrite)
                    {
                        // Batch script to activate Anaconda
                        sw.WriteLine(@"C:\Users\xxxxx\Anaconda3\Scripts\activate.bat");
                        // Activate your environment
                        sw.WriteLine("conda activate py3.7.4");                   
                        // run your script. You can also pass in arguments
                        sw.WriteLine("py pika_test.py");
                    }
                }
                // read multiple output lines
                while (!process.StandardOutput.EndOfStream)
                {
                    var line = process.StandardOutput.ReadLine();
                    Console.WriteLine(line);
                    Thread.Sleep(500);
                }
               
            }
        }
    }
