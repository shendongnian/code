    using System;  
    using System.Data.Sql;  
    using Microsoft.SqlServer.Server;  
    using System.Collections;  
    using System.Data.SqlTypes;  
    using System.Diagnostics;  
      
    public class TabularEventLog  
    {  
        [SqlFunction(FillRowMethodName = "FillRow")]  
        public static IEnumerable InitMethod(String logname)  
        {  
            return new EventLog(logname).Entries;    
        }  
      
        public static void FillRow(Object obj, out SqlDateTime timeWritten, out SqlChars message, out SqlChars category, out long instanceId)  
        {  
            EventLogEntry eventLogEntry = (EventLogEntry)obj;  
            timeWritten = new SqlDateTime(eventLogEntry.TimeWritten);  
            message = new SqlChars(eventLogEntry.Message);  
            category = new SqlChars(eventLogEntry.Category);  
            instanceId = eventLogEntry.InstanceId;  
        }  
    }
