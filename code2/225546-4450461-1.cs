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
            
                            string[] arrComputers = {".","clientN"}; 
                            foreach (string strComputer in arrComputers) 
                            { 
                                Console.WriteLine("=========================================="); 
                                Console.WriteLine("Computer: " + strComputer); 
                                Console.WriteLine("=========================================="); 
                                ManagementObjectSearcher searcher = new ManagementObjectSearcher
                                (
                                   new ManagementScope("\\\\" + strComputer + "\\root\\CIMV2",  oConn),
                                   new ObjectQuery( @"SELECT * FROM Win32_NTLogEvent WHERE Logfile = 'Security'")
                                );
             
             
                                foreach (ManagementObject queryObj in searcher.Get()) 
                                { 
                                    Console.WriteLine("-----------------------------------"); 
                                    Console.WriteLine("Win32_NTLogEvent instance"); 
                                    Console.WriteLine("-----------------------------------"); 
                                    Console.WriteLine("RecordNumber: {0}", queryObj["RecordNumber"]); 
                                    Console.WriteLine("SourceName: {0}", queryObj["SourceName"]); 
                                    Console.WriteLine("TimeGenerated: {0}", queryObj["TimeGenerated"]); 
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
--------------------------------------------------------------------------------
