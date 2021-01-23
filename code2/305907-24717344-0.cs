    enter code here
    EventLog eventLog = new EventLog();                    
    eventLog.Source = "ViewImagePDF";
    if (eventLog.OverflowAction != OverflowAction.OverwriteAsNeeded)
    {
        eventLog.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 1);
    }
    eventLog.WriteEntry("This is sample information", EventLogEntryType.Information); 
