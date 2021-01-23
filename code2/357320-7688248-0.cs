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
    // force close (kill) process after a certain timeout
    bool status = proc.WaitForExit(killTimeMS);
