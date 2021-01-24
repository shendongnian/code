    using System;
    using System.IO;
    using System.Diagnostics;
    
    namespace StartAndStopDotNetCoreApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string projectPath = @"C:\source\repos\StartAndStopDotNetCoreApp\WebApplication";
                string outputPath = @"C:\Temp\WebApplication";
    
                Console.WriteLine("Starting the app...");
                var process = new Process();
                process.StartInfo.WorkingDirectory = projectPath;
                process.StartInfo.FileName = "dotnet";
                process.StartInfo.Arguments = $"publish -o {outputPath}";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = true;
                process.Start();
                process.WaitForExit();
                process.Close();
                process.Dispose();
    
                process = new Process();
                process.StartInfo.WorkingDirectory = outputPath;
                process.StartInfo.FileName = "dotnet";
                process.StartInfo.Arguments = $"{projectPath.Split(@"\")[projectPath.Split(@"\").Length - 1]}.dll";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.CreateNoWindow = false;
                process.StartInfo.RedirectStandardOutput = true;
    
                process.Start();
    
                Console.WriteLine("Press anything to stop...");
                Console.Read();
    
                process.Kill();
            }
        }
    }
