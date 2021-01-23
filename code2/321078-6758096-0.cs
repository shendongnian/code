    /// using System.Management;  
    // don't forget! in VS you may have to add a new reference to this DLL
    ConnectionOptions op = new ConnectionOptions();
    op.Username = "REMOTE_USER";
    op.Password = "REMOTE_PASSWORD";
    ManagementScope sc = new ManagementScope(@"\\REMOTE_COMPUTER_NAME\root\cimv2", op);
    ObjectQuery query = new ObjectQuery("Select * from Win32_Process");
    ManagementObjectSearcher searcher = new ManagementObjectSearcher(sc, query);
    ManagementObjectCollection result = searcher.Get();
    foreach (ManagementObject obj in result)
    {
         if (obj["Caption"] != null) Console.Write(obj["Caption"].ToString() + "\t");
         if (obj["CommandLine"] != null) Console.WriteLine(obj["CommandLine"].ToString());
    }
