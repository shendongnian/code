    int count; //your result  
    
    //When yesterday became today
    DateTime yesterday = DateTime.Now.Subtract(new TimeSpan(24, 0, 0));  
 
    using (EventLog appLog = new EventLog("System"))
    {
        count = appLog.Entries.OfType<EventLogEntry>().Where(
            e => (e.Source.ToUpperInvariant == "USER32") && 
                 (e.TimeGenerated > yesterday)).Count();
    }
