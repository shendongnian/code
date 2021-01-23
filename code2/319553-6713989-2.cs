    //To get the process instance
    Process  application = null;
    foreach (var process in Process.GetProcesses())
    {
        if (process.ProcessName == "The Process Name")
        {
            application = process;
            break;
        }
    }
    //to check if the process UI is not responding
    if (application.Responding)
    { 
        //
    }
