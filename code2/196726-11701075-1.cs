    Process[] processes = Process.GetProcessesByName("iexplore");
            foreach (Process process in processes)
            {
                process.Kill();
            }
  
