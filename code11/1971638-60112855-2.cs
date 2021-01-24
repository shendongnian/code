    String findThisProcess = "Roblox";
 
    foreach (Process process in Process.GetProcesses()) //provides you with a list of all running processes
    {
        try
        {           
            if (process.ProcessName.Contains(findThisProcess, StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine($"Process: {Path.GetFileName(process.MainModule.FileName)}, Name: {process.ProcessName}");
                process.Kill();
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
    }
