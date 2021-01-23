    var processQuery = new SelectQuery("SELECT Commandline FROM Win32_Process");
    var scope = new System.Management.ManagementScope(@"\\.\root\CIMV2");
    var searcher = new ManagementObjectSearcher(scope, processQuery);
    ManagementObjectCollection processes = searcher.Get();
    foreach (var process in processes)
    {
         Console.WriteLine(process["Commandline"]);
    }
