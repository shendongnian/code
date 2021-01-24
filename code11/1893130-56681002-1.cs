    DiagnosticAccessStatus diagnosticAccessStatus =
    await AppDiagnosticInfo.RequestAccessAsync();
    switch (diagnosticAccessStatus)
    {
        case DiagnosticAccessStatus.Allowed:
             IReadOnlyList<ProcessDiagnosticInfo> processes = ProcessDiagnosticInfo.GetForProcesses();
             var p = processes.Where(x => x.ExecutableFileName == "ts3client_win64.exe"||x.ExecutableFileName == "ts3client_win32.exe").FirstOrDefault();
             if (p!= null)
             {
                 //TODO:...
             }
             break;
        case DiagnosticAccessStatus.Limited:
             break;
    }
