    string remoteMachine = "RemPC01";
    string remoteProcess = string.Format("psexec \\ {0} TZUTIL /s 'Central Standard Time', remoteMachine);
    Process process = new Process();
    process.StartInfo.FileName = remoteProcess;
    process.Start();
