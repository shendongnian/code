    Process process = Process.Start(startInfo);
    
    process.EnableRaisingEvents = true;
    
    bool execTimeout = false;
    
    // this call back will be called when timer ticks, Timeout for process.
    TimerCallback callBack = (_process) =>
    {
        // if the process didn't finish exexuting
        // and the timeout has reached 
        // then kill the process.
        if (!(_process as Process).HasExited)
        {
            execTimeout = true;
            (_process as Process).Kill();
        }
    };
    
    int timeout = 4000; // 4 seconds
    System.Threading.Timer timer = new System.Threading.Timer(callBack, 
                                         process, timeout, Timeout.Infinite);
    
    // block untill finishing executing [Sync calling]
    process.WaitForExit();
    
    // Disable the timer. because the process has finished executing.
    timer.Change(Timeout.Infinite, Timeout.Infinite);
    
    // if the process has finished by timeout [The timer which declared above]
    // or finished normally [success or failed].
    if (execTimeout)
    {
        // Write in log here
    }
    else
    {
        string standardOutput = process.StandardOutput.ReadToEnd();
        string standardError = process.StandardError.ReadToEnd();
    }
