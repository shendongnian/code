    static void RestartProcess(int pid, string processName )
        {
            // Wait for the process to terminate
            Process process = null;
            try
            {
                process = Process.GetProcessById(pid);
                process.Close();
            }
            catch (ArgumentException ex)
            {
                // If the process doesn't exist.
            }
            Process.Start(processName, "");
        }
