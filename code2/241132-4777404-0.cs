    using System;
    using System.IO;
    using Microsoft.Win32;
    using System.Diagnostics;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length >= 0 && !string.IsNullOrEmpty(args[0]) && File.Exists(args[0]))
            {
                var programs = new InstalledPrograms();
                var programKey = "RealPlay.exe".ToLowerInvariant();
                if (programs.ContainsKey(programKey))
                {
                    var programPath = programs[programKey];
                    if (!string.IsNullOrEmpty(programPath) && File.Exists(programPath))
                    {
                        var process = new Process();
                        process.StartInfo = new ProcessStartInfo(programPath);
                        process.StartInfo.Arguments = args[0];
                        if (process.Start())
                        {
                            Console.WriteLine("That was easy!");
                        }
                        else
                        {
                            Console.WriteLine("Hell's bells and buckets of blood, we seem to have hit a snag!");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Specify a file as an argument, silly!");
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        class InstalledPrograms : Dictionary<string, string>
        {
            static string PathKeyName = "Path";
            static string RegistryKeyToAppPaths = @"SOFTWARE\Microsoft\Windows\CurrentVersion\App Paths";           
            public InstalledPrograms()
            {
                Refresh();
            }
            public void Refresh()
            {
                Clear();
                using (var registryKey = Registry.LocalMachine.OpenSubKey(RegistryKeyToAppPaths))
                {
                    var executableFullPath = string.Empty;
                    foreach (var registrySubKeyName in registryKey.GetSubKeyNames())
                    {
                        using (var registrySubKey = registryKey.OpenSubKey(registrySubKeyName))
                        {
                            executableFullPath = registrySubKey.GetValue(string.Empty) as string;
                            Add(registrySubKeyName.ToLowerInvariant(), executableFullPath);
                        }
                    }
                }
            }
        }
    }
