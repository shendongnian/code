    using System.Diagnostics;
    public static bool KillProcess(string name)
    {
        try
        {
            var process = Process.GetProcesses().SingleOrDefault(p => p.ProcessName == name);
            process.WaitForExit(); 
            return true;
        }
        catch (Exception)
        {
            //throw;
            return false;
        }
    }
