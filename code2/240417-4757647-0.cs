    public static string ListAllProcesses()
    {
        StringBuilder sb = new StringBuilder();
     
        // list out all processes and write them into a stringbuilder
        ManagementClass MgmtClass = new ManagementClass("Win32_Process");
       
        foreach (ManagementObject mo in MgmtClass.GetInstances())
        {
            sb.Append("Name:\t" + mo["Name"] + Environment.NewLine);
            sb.Append("ID:\t" + mo["ProcessId"] + Environment.NewLine);
            sb.Append(Environment.NewLine);
        }
        return sb.ToString();
    }
