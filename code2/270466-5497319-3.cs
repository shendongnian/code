    // include the namespace
    using System.Management;
    var wmiQueryString = "SELECT ProcessId, ExecutablePath, CommandLine FROM Win32_Process";
    using (var searcher = new ManagementObjectSearcher(wmiQueryString))
    using (var results = searcher.Get())
    {
        var query = from p in Process.GetProcesses()
                    join mo in results.Cast<ManagementObject>()
                    on p.Id equals (int)(uint)mo["ProcessId"]
                    select new
                    {
                        Process = p,
                        Path = (string)mo["ExecutablePath"],
                        CommandLine = (string)mo["CommandLine"],
                    };
        foreach (var item in query)
        {
            // Do what you want with the Process, Path, and CommandLine
        }
    }
