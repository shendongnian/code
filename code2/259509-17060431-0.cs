    foreach (System.Management.ManagementObject Process in Processes.Get())
    {
        if (Process["ExecutablePath"] != null && 
            System.IO.Path.GetFileName(Process["ExecutablePath"].ToString()).ToLower() == "explorer.exe" )
        {
            string[] OwnerInfo = new string[2];
            Process.InvokeMethod("GetOwner", (object[])OwnerInfo);
    
            Console.WriteLine(string.Format("[main] Windows Logged-in Interactive UserName= {0}", OwnerInfo[0]));
    
            break;
        }
    }
