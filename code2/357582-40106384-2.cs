    {
        string sSource = "Application Name";
        string sLog = "Application";
        EventInstance eventInstance = new EventInstance(0, 0, EventLogEntryType.Error);
        List<string> sEvent = new List<string>();
        sEvent.Add("Message 1");
        sEvent.Add("Message 2");
        sEvent.Add("Message 3");
        // Check if Event Source was created (Possibly throw error if you are not running with high privilege)
        if (!EventLog.SourceExists(sSource))
            EventLog.CreateEventSource(sSource, sLog);            
        EventLog.WriteEvent(sSource, eventInstance, sEvent.ToArray());
    }
