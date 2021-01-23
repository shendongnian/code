    static void ExecuteCommand(string command)
    {
        int ExitCode;
        ProcessStartInfo ProcessInfo;
        Process process;
        ProcessInfo = new ProcessStartInfo("cmd.exe", "/c " + command);
        ProcessInfo.CreateNoWindow = true;
        ProcessInfo.UseShellExecute = false;
        // *** Redirect the output ***
        ProcessInfo.RedirectStandardError = true;
        ProcessInfo.RedirectStandardOutput = true;
        
        process = Process.Start(ProcessInfo);
        process.WaitForExit(); 
        
        // *** Read the streams ***
        string output = process.StandardOutput.ReadToEnd();
        string error = process.StandardError.ReadToEnd();
        ExitCode = process.ExitCode;
        Console.WriteLine("output>>" + (String.IsNullOrEmpty(output) ? "(none)" : output));
        Console.WriteLine("error>>" + (String.IsNullOrEmpty(error) ? "(none)" : error));
        Console.WriteLine("ExitCode: " + ExitCode.ToString(), "ExecuteCommand");
        process.Close();
    }
    static void Main()
    {
        ExecuteCommand("echo testing");
    }
