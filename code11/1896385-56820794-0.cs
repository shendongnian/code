    Dictionary<string, Process> processes = new Dictionary<string, Process>();
    
    static void StartProcess(string args)
    {
        var process = new Process
        {
            StartInfo = { FileName = "FileName", Arguments = args }
        };
        process.Start();
        processes.Add(args, process);
    }
    static void StopProcess(string args)
    {
        var process = processes[args];
        process.Kill();
        process.Dispose();
        processes.Remove(args);
    }
