    EventLog el1 = new EventLog();
    el1.Log = "Application";
    el1.Source = "SharePoint Foundation";
    el1.WriteEntry("Start", EventLogEntryType.Information);
    var c = SPContext.Current;
    el1.WriteEntry("SPContext : " + (c == null ? "nothing" : "something"), EventLogEntryType.Information);
    if (c != null) el1.WriteEntry("Web ID: " + (c.Web == null ? "nothing" : "something"), EventLogEntryType.Information);
