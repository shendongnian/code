    [LayoutRenderer("ExtendedException")]
        public class ExtendedExceptionLayoutRenderer : ExceptionLayoutRenderer
        {
            protected override void Append(System.Text.StringBuilder builder, LogEventInfo logEvent)
            {
                var exception = logEvent.Exception;
                var type = exception.GetType();
                var properties = type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public);
    
                var logEntries = new SortedDictionary<string, string>();
    
                foreach (var property in properties)
                {
                    var name = property.Name;
                    var value = property.GetValue(exception, null).ToString();
                    logEntries.Add(name, value);
                }
    
                foreach (var entry in logEntries)
                {
                    builder.AppendFormat("{0}: {1} ", entry.Key, entry.Value);
                }
    
                base.Append(builder, logEvent);
            }
        }
