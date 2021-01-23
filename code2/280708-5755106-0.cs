    Use System.Management;
    //Return all processes
    public static string ListAllProcesses()
    {
        StringBuilder sbAllProcess = new StringBuilder();
        // list out all processes and write them into a stringbuilder
        ManagementClass MgmtClass = new ManagementClass("Win32_Process");
    
        foreach (ManagementObject mobject in MgmtClass.GetInstances())
        {
            sbAllProcess .Append("Name:\t" + mobject ["Name"] + Environment.NewLine);
            sbAllProcess .Append("ID:\t" + mobject ["ProcessId"] + Environment.NewLine);
            sbAllProcess .Append(Environment.NewLine);
        }
    
        return sbAllProcess .ToString();
    }
    //Return all applications
    public static string ListAllApplications()
    {
        StringBuilder sbAllApplication = new StringBuilder();
    
        foreach (Process runningProcess in Process.GetProcesses("."))
        {
            try
            {
                if (runningProcess .MainWindowTitle.Length > 0)
                {
                    sbAllApplication .Append("Window Title:\t" + runningProcess .MainWindowTitle.ToString()+ Environment.NewLine);
                    sbAllApplication .Append("Process Name:\t" + runningProcess .ProcessName.ToString() + Environment.NewLine);
                    sbAllApplication .Append("Window Handle:\t" + runningProcess .MainWindowHandle.ToString() + Environment.NewLine);
                    sbAllApplication .Append("Memory Allocation:\t" + runningProcess .PrivateMemorySize64.ToString() + Environment.NewLine);
                    sbAllApplication .Append(Environment.NewLine);
                }
            }
            catch { }
        }
        return sbAllApplication .ToString();
    }
