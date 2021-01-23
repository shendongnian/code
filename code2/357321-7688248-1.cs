    // check for processes
    Process[] processes = Process.GetProcessesByName("nameOfExecutable");
    foreach (Process proc in processes)
    {   
       // do stuff
    }
    // start process (need path)
    Process.Start("pathToExecutable");
    // close gui process gently (if needed)
    bool status = proc.CloseMainWindow();
    // wait for process to close gently
    bool status = proc.WaitForExit(killTimeMS);
    // force close (kill) process
    proc.Kill();
