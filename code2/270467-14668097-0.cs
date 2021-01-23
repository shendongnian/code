    using System;
    using System.Management;
    using System.Diagnostics;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                int processID = 6680;   // Change for the process you would like to use
                Process process = Process.GetProcessById(processID);
                string path = ProcessExecutablePath(process);
            }
    
            static private string ProcessExecutablePath(Process process)
            {
                try
                {
                    return process.MainModule.FileName;
                }
                catch
                {
                    string query = "SELECT ExecutablePath, ProcessID FROM Win32_Process";
                    ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
    
                    foreach (ManagementObject item in searcher.Get())
                    {
                        object id = item["ProcessID"];
                        object path = item["ExecutablePath"];
    
                        if (path != null && id.ToString() == process.Id.ToString())
                        {
                            return path.ToString();
                        }
                    }
                }
    
                return "";
            }
        }
    }
