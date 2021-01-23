    IDictionary *contextInfo* = new Hashtable();
    
       contextInfo.Add("Additional Info", "Some information I wanted logged");
    
       DebugInformationProvider provider = new DebugInformationProvider();
       provider.PopulateDictionary(contextInfo);
    
       LogEntry logEntry           = new LogEntry();
       logEntry.Message            = "Logged with context specific information";
       logEntry.ExtendedProperties = *contextInfo*;
    
       Logger.Write(logEntry);
