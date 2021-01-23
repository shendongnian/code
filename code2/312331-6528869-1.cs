    //find your log in the windows EventLog by name
    EventLog log = null;
    foreach (EventLog eventLog in EventLog.GetEventLogs())
    {
        if (string.Compare(eventLog.Log, logName, true) == 0)
        {
            log = eventLog;
            break;
        }
    }
    //modify log settings
    log.ModifyOverflowPolicy(OverflowAction.OverwriteAsNeeded, 7);
    log.MaximumKilobytes = MaxLogSize;
    //write to event to log
    EventLog.WriteEntry(source, message);
    //more advance writing to log instance
    long instanceId;
    int categoryId;;
    EventLogEntryType entryType;
    byte[] binaryData;
    object[] values;
    
    EventInstance eventInstance = new EventInstance(instanceId, categoryId, entryType);
    log.WriteEvent(eventInstance, binaryData, values);
