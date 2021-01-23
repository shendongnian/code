            foreach (var process in Process.GetProcesses())
            {
                if (process.Modules.OfType<ProcessModule>().Any(m => m.ModuleName == "mscoree.dll"))
                {
                    Console.WriteLine("{0} is a .NET process", process.ProcessName);
                }
            }
