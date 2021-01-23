    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.IO;
    using System.Linq;
    using System.Management;
    class Program
    {
        static void Main(string[] args)
        {
            var searcher =
                new ManagementObjectSearcher("SELECT * FROM Win32_Service WHERE Started=1 AND StartMode=\"Auto\"");
            foreach (ManagementObject service in searcher.Get())
            {
                foreach (var prop in service.Properties)
                {
                    if (prop.Name != "PathName" || prop.Value == null)
                        continue;
                    var cmdLine = prop.Value.ToString();
                    var path = cmdLine.SplitCommandLine().ToArray()[0] + ".config";
                    if (File.Exists(path))
                    {
                        var serviceConfig = ConfigurationManager.OpenExeConfiguration(path);
    /***/
                    }
                    break;
                }
            }
        }
    }
