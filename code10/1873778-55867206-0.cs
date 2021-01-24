    using System.Management;
    ConnectionOptions oConn = new ConnectionOptions();
    ManagementScope oMs = new ManagementScope("\\\\localhost", oConn);
    ObjectQuery oQuery = new ObjectQuery("select * from Win32_ComputerSystem");
    ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
    ManagementObjectCollection oReturnCollection = oSearcher.Get();
  
    foreach (ManagementObject oReturn in oReturnCollection)
    {
        if (oReturn["UserName"] == null)
        {
            // No active session
            Console.Write("UserName: null");
        }
        else
        {
            // Active session
            Console.Write("UserName: " + oReturn["UserName"].ToString());
        }                            
    }
