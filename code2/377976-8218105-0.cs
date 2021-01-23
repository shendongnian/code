    var log = new EventLog("Application");
    res = from entry in log.Entries.Cast<EventLogEntry>()
     entry.TimeGenerated >= start
      select entry;
        
        
                    foreach (var e in res)
                    {
                        Console.WriteLine(e.Message);
                    }
    
     
       
