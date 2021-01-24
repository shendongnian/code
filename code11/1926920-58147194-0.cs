    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Diagnostics;
    
    namespace TaskManager
    {
        class Program
        {
            static void Main(string[] args)
            {
                Process[] processList = Process.GetProcesses();
                foreach(Process process in processList)
                {
                    try
                    {
                        DateTime localDate = DateTime.Now;
                        Console.WriteLine(@" {0} | ID: {1} | Status {2} | Memory {3} MB | Total Run Time {4}", process.ProcessName, process.Id, process.Responding, process.PrivateMemorySize64 / 1000000, localDate - process.StartTime);
                    }
                    catch (Win32Exception ex)
                    {
                        Console.WriteLine(@"Unable to access process '{0}': {1}", process.Id, ex.Message);
                    }
                }
                Console.ReadLine();
            }
        }
    }
