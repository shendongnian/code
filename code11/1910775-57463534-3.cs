    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    namespace Demo
    {
        class Program
        {
            static void Main()
            {
                var eventLog = new EventLog("System");
                var mostRecentWake =
                    EnumerateLog(eventLog, "Microsoft-Windows-Power-Troubleshooter")
                    .OrderByDescending(item => item.TimeGenerated)
                    .First();
                Console.WriteLine(mostRecentWake.TimeGenerated);
            }
            public static IEnumerable<EventLogEntry> EnumerateLog(EventLog log, string source)
            {
                foreach (EventLogEntry entry in log.Entries)
                    if (entry.Source == source)
                        yield return entry;
            }
        }
    }
