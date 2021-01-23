    using System;
    using System.Collections.Generic;
    using System.Management;
    using System.Text;
    
    namespace ConsoleApplication13
    {
        class Program
        {
            static void Main(string[] args)
            {
                try
                {
                    ManagementObjectSearcher searcher =
                        new ManagementObjectSearcher("root\\CIMV2",
                        "SELECT * FROM Win32_WinSAT");
    
                    foreach (ManagementObject queryObj in searcher.Get())
                    {
                        Console.WriteLine("CPUScore: {0}", queryObj["CPUScore"]);
                        Console.WriteLine("D3DScore: {0}", queryObj["D3DScore"]);
                        Console.WriteLine("DiskScore: {0}", queryObj["DiskScore"]);
                        Console.WriteLine("GraphicsScore: {0}", queryObj["GraphicsScore"]);
                        Console.WriteLine("MemoryScore: {0}", queryObj["MemoryScore"]);
                        Console.WriteLine("TimeTaken: {0}", queryObj["TimeTaken"]);
                        Console.WriteLine("WinSATAssessmentState: {0}", queryObj["WinSATAssessmentState"]);
                        Console.WriteLine("WinSPRLevel: {0}", queryObj["WinSPRLevel"]);
                    }
                }
                catch (ManagementException e)
                {
                    Console.WriteLine(e.Message);
                }
                Console.Read();
            }
        }
    }
