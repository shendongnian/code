                ConnectionOptions oConn = new ConnectionOptions();
                System.Management.ManagementScope oMs = new System.Management.ManagementScope("\\\\localhost", oConn);
    
    
                System.Management.ObjectQuery oQuery = new System.Management.ObjectQuery("select * from Win32_ComputerSystem");
                ManagementObjectSearcher oSearcher = new ManagementObjectSearcher(oMs, oQuery);
                ManagementObjectCollection oReturnCollection = oSearcher.Get();
    
                foreach (ManagementObject oReturn in oReturnCollection) {
                    Console.WriteLine(oReturn["UserName"].ToString().ToLower());
                }
