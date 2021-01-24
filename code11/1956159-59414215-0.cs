     private static void KillExcel()
            {
                foreach (Process process in Process.GetProcessesByName("excel"))
                {
                    if (!process.HasExited)
                    {
                        process.Kill();
                    }
                }
            }
