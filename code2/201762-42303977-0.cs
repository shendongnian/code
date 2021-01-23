    private void runRemoteApp(string[] processToRun, string machineName)
    {
        var connection = new ConnectionOptions();
        var wmiScope = new ManagementScope(String.Format("\\\\{0}\\root\\cimv2", machineName), connection);
        var wmiProcess = new ManagementClass(wmiScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());
        wmiProcess.InvokeMethod("Create", processToRun);
    }
    private void logoffMachine(string machineName)
    {
        var processToRun = new[] { "logoff.exe console" };
        runRemoteApp(processToRun, machineName);
    }
