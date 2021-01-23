    private static int RunProcess(string processName, string arguments)
    {
        Process process = new Process();
        process.StartInfo.FileName = processName;
        process.StartInfo.Arguments = arguments;
        process.Start();
        process.WaitForExit();
        return process.ExitCode;
    }
