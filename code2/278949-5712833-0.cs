    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2\\Applications\\WindowsParentalControls", "SELECT * FROM WpcUserSettings");
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        if (queryObj["SID"] == "The user SID to modify")
                        {
                            //set  the properties here
    
                            queryObj["AppRestrictions"] = true;
                            queryObj["HourlyRestrictions"] = true;
                            queryObj["LoggingRequired"] = false;
                            //queryObj["LogonHours"] = ;
                            //queryObj["OverrideRequests"] = ;
                            queryObj["WpcEnabled"] = true;
                            queryObj.Put();
                        }
                    }
                }
                catch (ManagementException e)
                {
                    Console.WriteLine("An error occurred setting the WMI data: " + e.Message);
                }
                Console.ReadKey();
            }
        }
    }
