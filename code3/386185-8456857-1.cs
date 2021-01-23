    using System;
    using System.Management;  // NOTE: add a reference to System.Management!
    class Program {
        static void Main(string[] args) {
            ManagementObjectSearcher searcher =
                new ManagementObjectSearcher("root\\CIMV2",
                "SELECT * FROM Win32_Process");
    
            foreach (ManagementObject queryObj in searcher.Get()) {
                Console.WriteLine(queryObj["CommandLine"]);
            }
            Console.ReadLine();
        }
    }
