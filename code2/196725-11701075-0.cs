    Process[] processes = Process.GetProcessesByName("iexplorer");
            foreach (Process process in processes)
            {
                process.Kill();
            }
  
