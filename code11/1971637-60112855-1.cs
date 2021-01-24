    String findThisProcess = "Roblox";
 
    foreach (Process process in Process.GetProcesses()) //provides you with a list of all running processes
    {
        try
        {           
            if (process.ProcessName.Contains(findThisProcess))
            {
                Console.WriteLine("App: {0}, Name: {1}", Path.GetFileName(process.MainModule.FileName), process.ProcessName);
                process.Kill();
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
    }
