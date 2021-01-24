    var startInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    WorkingDirectory = fileDirectoryPath,
                    Arguments = "ReportGeneratorApp.dll",
                    RedirectStandardOutput = true
                };
    
                using (Process process = new Process())
                {
                    process.StartInfo = startInfo;
    
                    process.Start();
                    process.WaitForExit();
    
                    var output = await process.StandardOutput.ReadToEndAsync();
                }
