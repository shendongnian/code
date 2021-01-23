    Process userCommandProc = Process.Start(procStart);
    userCommandProc.WaitForExit();
    
    if (userCommandProc.ExitCode != 0)
    {
        // Something has (very likely) gone wrong
    }
    else
    {
        // Most likely working
    }
