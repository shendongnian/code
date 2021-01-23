    private const string CatchupLineToIndicateLogDump = "mp4:production/CATCHUP/";
    private const string BatchFileLocation = "Command.bat";
    
    private void CheckLog()
    {
        while (true)
        {
            Thread.Sleep(5000);
            if (System.IO.File.Exists(BatchFileLocation))
            {
                if (doesFileContainStr(BatchFileLocation, CatchupLineToIndicateLogDump))
                {
                    RemoveLogAndDump();
                    return;
                }
            }
        }
    }
    
    private bool doesFileContainStr(string FileLoc, string StrToCheckFor)
    {
      // ... code for checking the existing of a string within a file
      // (and returning back whether the string was found.)
    }
    
    private void RemoveLogAndDump()
    {
      // ... your code to call RemoveEXELog and kick off test.exe
    }
