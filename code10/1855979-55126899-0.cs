    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Windows.System;
    using Windows.System.Diagnostics;
    class ProcessChecker
    {
    public static async Task<bool> CheckForRunningProcess(string processName)
        {
            //Requests permission for app.
            await AppDiagnosticInfo.RequestAccessAsync();
            //Gets the running processes.
            var processes = ProcessDiagnosticInfo.GetForProcesses();
            //Returns result of searching for process name.
            return processes.Any(processDiagnosticInfo => processDiagnosticInfo.ExecutableFileName.Contains(processName));
        }
    }
