           const string str = "MRS_Admin";
            foreach (Process process in Process.GetProcesses())
            {
                if (process.ProcessName.StartsWith(str))
                {
                    Console.WriteLine(@"Killing process " + str);
                    process.Kill();
                }
            }
