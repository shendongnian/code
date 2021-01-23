    public static void WriteException(Exception exception)
    {
    	EventLog eventLog = null;
    	try
    	{
    		StringBuilder message = new StringBuilder();
    		message.Append("[").Append(exception.Source).Append(" - ").Append(exception.GetType().FullName);
    		message.Append("]").Append(@"\r\n").Append(exception.ToString());              
    
    		eventLog = new EventLog();
    		eventLog.Log = "LOG_FILE_NAME";
    		eventLog.Source = "APP_IDENTIFIER";
    		eventLog.WriteEntry(message.ToString(), EventLogEntryType.Warning);
    	}
    	catch (Exception ex) {/*DO-NOTHING*/ string msg = ex.Message; }
    	finally { if (eventLog != null) { eventLog.Dispose(); } eventLog = null; }
    }
