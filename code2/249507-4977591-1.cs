    Process p = new Process();
    p.StartInfo.FileName = "hello.exe";
    bool s = p.Start();
    if (s) {
      // A new process was started
    } else {
      // The process was already running
    }
    p.WaitForExit();
