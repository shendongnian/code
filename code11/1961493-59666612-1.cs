    using log4net.Appender;
    using log4net.Core;
    using System;
    using System.Collections.Generic;
    
    namespace MaxRateExample
    {
        public class MaxRateForwardingAppender : ForwardingAppender
        {
            // Maximum 10 events per second. You can move this to config file.
            private const int MaxRateSeconds = 1;
            private const int MaxRateEvents = 10;
    
            private List<DateTime> Dates { get; }
    
            public MaxRateForwardingAppender()
            {
                Dates = new List<DateTime>();
            }
    
            protected override void Append(LoggingEvent loggingEvent)
            {
                if (LogEvent())
                    base.Append(loggingEvent);
            }
    
            protected override void Append(LoggingEvent[] loggingEvents)
            {
                if (LogEvent())
                    base.Append(loggingEvents);
            }
    
            private bool LogEvent()
            {
                Dates.RemoveAll(x => (DateTime.Now - x).Seconds > MaxRateSeconds);
    
                if (Dates.Count <= MaxRateEvents)
                {
                    Dates.Add(DateTime.Now);
                    return true;
                }
    
                return false;
            }
        }
    }
