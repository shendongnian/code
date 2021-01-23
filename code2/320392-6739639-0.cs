    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using NLog;
    using NLog.LayoutRenderers;
    
    namespace MyNLogExtensions.NLog
    {
      [LayoutRenderer("LogLevelOrdinal")]
      class LogLevelOrdinalLayoutRenderer : LayoutRenderer
      {
        IDictionary<LogLevel, int> ordinals;
    
        public override void  Initialize()
        {
          base.Initialize();
    
          ordinals = GetLogLevels()
                      .OrderBy(level => level)
                      .Select((level, index) => new { Level = level, Ordinal = index })
                      .ToDictionary( x => x.Level, x => x.Ordinal);
        }
    
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
          int level = 0;
    
          if (!ordinals.TryGetValue(logEvent.Level, out level)) level = 99;
    
          builder.Append(level);
        }
    
        protected override int GetEstimatedBufferSize(LogEventInfo logEvent)
        {
          return 1;
        }
    
        //
        // LogLevel is a static class with a static member for each of the different log levels.
        // The LogLevel ordinal is not exposed publically (i.e. an ordinal indicating the relative
        // "importance" of a LogLevel value).
        // The implementation of LogLevel.GetHashCode actually does return the ordinal, but it doesn't
        // seem right to rely on that implementation detail.
        // In the end, this LayoutRenderer is really just to allow for producing a numeric value to represent
        // a particular log level value's "position" relative to the other lob levels.  As such, 
        // We can just get all of the known log level values, order them (they are sortable), and assign our
        // own ordinal based on the position of the log level value in the resulting sorted list.
        //
        // This helper function exposes the known log level values as IEnumerable<LogLevel> so that we can
        // easily use LINQ to build a dictionary to map LogLevel to ordinal.
        //
        internal IEnumerable<LogLevel> GetLogLevels()
        {
          yield return LogLevel.Trace;
          yield return LogLevel.Debug;
          yield return LogLevel.Info;
          yield return LogLevel.Warn;
          yield return LogLevel.Error;
          yield return LogLevel.Fatal;
        }
    
      }
    }
