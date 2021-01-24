    using System;
    using System.Text;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    
    namespace NewCmd
    {
        class Program
        {
            [Flags]
            private enum ProcessAccessFlags : uint
            {
                QueryLimitedInformation = 0x00001000
            }
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern bool QueryFullProcessImageName
                (
                [In] IntPtr hProcess, 
                [In] int dwFlags, 
                [Out] StringBuilder lpExeName, 
                ref int lpdwSize
                );
    
            [DllImport("kernel32.dll", SetLastError = true)]
            private static extern IntPtr OpenProcess
                (
                ProcessAccessFlags processAccess, 
                bool bInheritHandle, 
                int processId
                );
    
            static void Main(string[] args)
            {
                foreach (Process p in Process.GetProcesses())
                {
                    Console.WriteLine(String.Format("Id: {0} Name: {1}", p.Id, p.ProcessName));
                    Console.WriteLine(String.Format("Path: {0}", GetProcessFilename(p)));
                }
                Console.ReadLine();
            }
            
            static String GetProcessFilename(Process p)
            {
                int capacity = 2000;
                StringBuilder builder = new StringBuilder(capacity);
                IntPtr ptr = OpenProcess(ProcessAccessFlags.QueryLimitedInformation, false, p.Id);
                if (!QueryFullProcessImageName(ptr, 0, builder, ref capacity))
                {
                    return "[Missing]";
                }
                else
                {
                    return builder.ToString();
                }
            }
        }
    }
