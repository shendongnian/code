    String findThisProcess = "Roblox";
 
    foreach (Process process in Process.GetProcesses())
    {
        try
        {           
            if (process.ProcessName.Contains(findThisProcess))
            {
                Console.WriteLine("App Name: {0}, Process Name: {1}", Path.GetFileName(process.MainModule.FileName), process.ProcessName);
                process.Kill();
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex);
        }
    }
