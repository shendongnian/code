    using System;
    using System.Management;
    
    namespace WMITest
    {
        class Program
        {
            static void Main(string[] args)
            {
                ManagementObjectSearcher searcher = 
                    new ManagementObjectSearcher(
                        "Select * From Win32_NetworkAdapter");
                
                foreach (ManagementObject adapter in searcher.Get())
                {
                    Console.WriteLine(adapter["Name"]);
    
                    foreach(ManagementObject configuration in
                        adapter.GetRelated("Win32_NetworkAdapterConfiguration"))
                    {
                        Console.WriteLine(configuration["Caption"]);
                    }
    
                    Console.WriteLine();
                }
            }
        }
    }
