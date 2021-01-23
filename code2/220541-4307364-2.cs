      public class ActivityIdLayoutConverter : PatternLayoutConverter
      {
        protected override void Convert(System.IO.TextWriter writer, LoggingEvent loggingEvent)
        {
          writer.Write(Trace.CorrelationManager.ActivityId.ToString());
        }
      }
