    using System;
    using System.Management;
    namespace WmiConnectRemote
    {
        class Program
        {
            static void Main(string[] args)
            {
                var machine = "XXXX";
                var options = new ConnectionOptions { Username = "XXXX", Password = "XXXX" };
                var scope = new ManagementScope(@"\\" + machine + @"\root\cimv2", options);
                var queryString = "select Name, Size, FreeSpace from Win32_LogicalDisk where DriveType=3"; var query = new ObjectQuery(queryString);
                var worker = new ManagementObjectSearcher(scope, query);
                var results = worker.Get();
                foreach (ManagementObject item in results)
                {
                    Console.WriteLine("{0} {2} {1}", item["Name"], item["FreeSpace"], item["Size"]);
                }
            }
        }
    }
