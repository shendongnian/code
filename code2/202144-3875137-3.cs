    using System.Diagnostics;
    public static bool StopProcess(string name)
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
