    using System;
    using System.Diagnostics;
    
    namespace ReadEventLog
    {
        class Program
        {
            static void Main(string[] args)
            {
    
                string logType = "System";
    
                EventLog ev = new EventLog(logType, "netsliisdev02b");
                if (ev.Entries.Count <= 0)
                    Console.WriteLine("No Event Logs in the Log :" + logType);
    
                // Loop through the event log records. 
                for (int i = 0; i < ev.Entries.Count; i++)
                {
                    EventLogEntry CurrentEntry = ev.Entries[i];
    
                    //use DateTime type to compare on CurrentEntry.TimeGenerated
    
                    if (CurrentEntry.Source.ToUpper() == "USER32")
                    {
                        Console.WriteLine("Event ID : " + CurrentEntry.InstanceId);
                        Console.WriteLine("Entry Type : " + CurrentEntry.EntryType.ToString());
                        Console.WriteLine("Message :  " + CurrentEntry.Message + "\n");
                    }
                }
                ev.Close();
            }
        }
    }
