    namespace MyApp
    {
        namespace Diagnostics
        {
            public class DateTimeConsoleTraceListener : ConsoleTraceListener
            {
                public override void Write(string message)
                {
                    base.Write(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fffffff ") + message);
                }
            }
    
            public class DateTimeTextWriterTraceListener : TextWriterTraceListener
            {
                public DateTimeTextWriterTraceListener(string fileName) : base(fileName) { }
    
                public override void Write(string message)
                {
                    base.Write(DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss.fffffff ") + message);
                }
            }
        }
    }
