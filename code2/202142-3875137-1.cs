    using System.Diagnostics;
    public static bool KillProcess(string name, int timeout)
    {
        try
        {
            var process = Process.GetProcesses().SingleOrDefault(p => p.ProcessName == name);
            process.WaitForExit(timeout);
            return true;
        }
        catch (Exception)
        {
            //throw;
            return false;
        }
    }
