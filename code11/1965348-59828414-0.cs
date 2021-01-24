    public class HtLayoutRenderer : LayoutRenderer
    {
        protected override void Append(StringBuilder builder, LogEventInfo logEvent)
        {
           if ( logevent.Exception != null
             && logevent.Message == "{0}"
             && logevent.Parameters?.Length == 1
             && ReferenceEquals(logevent.Exception, logevent.Parameters[0])
           {
              // Exception given as single parameter without any message
           }
        }
    }
