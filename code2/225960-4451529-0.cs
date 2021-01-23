    using System;
    using System.Management;
    namespace WMISample
    {
        public class MyWMIQuery
        {
            public static void Main()
            {
                try
                {
                ConnectionOptions oConn = new ConnectionOptions(); 
                oConn.Impersonation = ImpersonationLevel.Impersonate; 
                oConn.EnablePrivileges = true;
                    string[] arrComputers = "clientName"};
                    foreach (string strComputer in arrComputers)
                    {
                        Console.WriteLine("==========================================");
                        Console.WriteLine("Computer: " + strComputer);
                        Console.WriteLine("==========================================");
    
                            ManagementObjectSearcher searcher = new ManagementObjectSearcher 
                            ( 
                               new ManagementScope("\\\\" + strComputer + "\\root\\CIMV2",  oConn), 
                               new ObjectQuery( @"SELECT * FROM CIM_DataFile WHERE Name = 'WhatyouWant.ToSearch'") 
                            ); 
    
                        foreach (ManagementObject queryObj in searcher.Get())
                        {
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("CIM_DataFile instance");
                            Console.WriteLine("-----------------------------------");
                            Console.WriteLine("Path: {0}", queryObj["Path"]);
                        }
                    }
                }
                catch(ManagementException err)
                {
                    MessageBox.Show("An error occurred while querying for WMI data: " + err.Message);
                }
            }
        }
    }
