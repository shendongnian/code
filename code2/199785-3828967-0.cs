    Process[] processes = Process.GetProcesses();
    foreach (Process process in processes) {
      if (process.ProcessName == "APP1.exe") {
        try {
          process.Kill();
          break;
          } catch (Exception) { 
            //handle any exception here
          }
        }
      }
    }
