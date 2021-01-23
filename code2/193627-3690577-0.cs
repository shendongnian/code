    using System;
    using System.Management;
    
    namespace ConsoleApplication10
    {
        class Program
        {
            static void Main(string[] args)
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", 
                    "SELECT * FROM Win32_IP4RouteTable WHERE Destination=\"0.0.0.0\"");
    
                int interfaceIndex = -1;
    
                foreach (var item in searcher.Get())
                {
                    interfaceIndex = Convert.ToInt32(item["InterfaceIndex"]);
                }
    
                searcher = new ManagementObjectSearcher("root\\CIMV2",
                    string.Format("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE InterfaceIndex={0}", interfaceIndex));
    
                foreach (var item in searcher.Get())
                {
                    var ipAddresses = (string[])item["IPAddress"];
                    
                    foreach (var ipAddress in ipAddresses)
                    {
                        Console.WriteLine(ipAddress);
                    }
                    
                }
            }
        }
    }
