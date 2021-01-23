    using System;
    using System.IO;
    using System.Diagnostics;
    using System.Text;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    class Program
    {
        [DllImport("kernel32.dll", CharSet = CharSet.Auto)]
        public static extern int GetShortPathName(
            [MarshalAs(UnmanagedType.LPTStr)]
            string path,
            [MarshalAs(UnmanagedType.LPTStr)]
            StringBuilder shortPath,
            int shortPathLength
            );
        static void Main(string[] args)
        {
            string scriptDirLong = Directory.GetParent(Process.GetCurrentProcess().MainModule.FileName).FullName;
            StringBuilder scriptDir = new StringBuilder(255);
            GetShortPathName(scriptDirLong, scriptDir, 255);
            string logDir = @"C:\log\registry\";
            string date = System.DateTime.Now.ToString("yyyyMMdd");
            string time = System.DateTime.Now.ToString("HHmmss");
            string ReadUsername = (string)Registry.GetValue(@"HKEY_LOCAL_MACHINE\SOFTWARE\COM\Upload", "I", null);
            Console.WriteLine(scriptDir + "\r\n" + logDir + "\r\n" + date + "\r\n" + time);
            Console.ReadKey();
            Process.Start("procmon.exe", 
                "/LoadConfig '" + scriptDir.ToString() + "\\registrymonitoring.pmc' /Quiet /AcceptEula /BackingFile " + 
                logDir + ReadUsername + "-" + date + "-" + time);
        }
    }
