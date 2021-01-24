    public class EventLogMgmt{   
    public static void Main(string[] args)
            {
            Stirng logName = "Security";
            String queryString = "<QueryList>  <Query Id="0" Path="Security"><Select Path="Security">*[System[(EventID = 5136)]]</Select></Query></QueryList>";
     EventLogQuery subscriptionQuery = new EventLogQuery(logName, PathType.LogName, queryString);
                    watcher = new EventLogWatcher(subscriptionQuery, null, true); //EventLog watcher                  
                    watcher.EventRecordWritten += new EventHandler<EventRecordWrittenEventArgs>(EventLogEventRead);
                    watcher.Enabled = true;                
    	}
    
    	 public void EventLogEventRead(object obj, EventRecordWrittenEventArgs arg)
            {
                if (arg.EventRecord != null)
                {
                    EventRecord eventInstance = arg.EventRecord;
                    String eventMessage = eventInstance.FormatDescription(); // You can get event information from FormatDescription API itself.
                    String eventMessageXMLFmt = eventInstance.ToXml(); // Getting event information in xml format
                }
            }
    }
