    using System;
    using System.Diagnostics;
    
    class Program
    {
        public static void printAllprocesses()
        {
            Process[] processlist = Process.GetProcesses();
    
            foreach (Process process in processlist)
            {
                try
                {
                    String fileName = process.MainModule.FileName;
                    String processName = process.ProcessName;
    
                    Console.WriteLine("processName : {0},  fileName : {1}", processName, fileName);
                }catch(Exception e)
                {
                    /* You will get access denied exception for system processes, We are skiping the system processes here */
                }
               
            }
        }
    
        static void Main()
        {
            printAllprocesses();
        }
    
    }
