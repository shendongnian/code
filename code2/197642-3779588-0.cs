    private static void MyLogEvent(String Message)
    {
      // Create an eEventLog instance and assign its source.
      using (EventLog myLog = new EventLog())
     {
       myLog.Source = "Informer Watchguard";
    
       // Write an informational entry to the event log.
       myLog.WriteEntry(Message);
     }
    }
