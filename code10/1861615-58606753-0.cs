    public static void ExecuteGitBashCommand(string fileName, string command, string workingDir)
    {
        ProcessStartInfo processStartInfo = new ProcessStartInfo(fileName, "-c \" " + command + " \"")
        {
            WorkingDirectory = workingDir,
            RedirectStandardOutput = true,
            RedirectStandardError = true,
            RedirectStandardInput = true,
            UseShellExecute = false,
            CreateNoWindow = true
        };
        var process = Process.Start(processStartInfo);       
        process.WaitForExit();
    
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        var exitCode = process.ExitCode;
        process.Close();
    }
