    using Newtonsoft.Json.Linq;
    using Serilog.Events;
    using Serilog.Sinks.EventLog;
    using System;
    using System.Linq;
    
    namespace IndependentFile.Extensions
    {
        public class LoggerSetupExtensions
        {
            public class EventLogFormatProvider : IFormatProvider, ICustomFormatter
            {
                public object GetFormat(Type formatType)
                {
                    return formatType == typeof(ICustomFormatter) ? this : null;
                }
    
                public string Format(string format, object arg, IFormatProvider formatProvider)
                {
                    return arg.ToString();
                }
            }       
    
            public class EventIdProvider : IEventIdProvider
            {
                public ushort ComputeEventId(LogEvent logEvent)
                {
                    var eventTypeProp = logEvent.Properties.FirstOrDefault(prop => prop.Key == "EventId");
    
                    if (eventTypeProp.Value == null)
                    {
                        return (ushort)LogValuesEnum.Unknown;
                    }
                    try
                    {
                        var val = eventTypeProp.Value;
                        string eventType = eventTypeProp.Value.ToString();
                        
                        //this is not the right way to parse the logEventPropertyValue
                        var parseEventType = JObject.Parse(eventType);
    
                        var eventIdInt = parseEventType["Id"].ToString();
    
                        if (eventType == null) return (int)LogValuesEnum.Unknown;
    
                        var tryParseEventId = Enum.TryParse<LogValuesEnum>(eventIdInt, ignoreCase: true, out var res);
                        if (tryParseEventId)
                        {
                            return (ushort)res;
                        }
    
                        return (ushort)LogValuesEnum.Unknown;
                    }
                    catch(Exception exc)
                    {
                        return (ushort)LogValuesEnum.Unknown;
                    }
                  
                }
            }
        }
    }
