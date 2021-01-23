    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;
    using System.Collections;
    
    namespace TraceExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                CustomTraceListener c = new CustomTraceListener("log.txt");
                Trace.Listeners.Add(c);
                Trace.WriteLine("WriteLine","Info");
                Trace.Flush();
            }
        }
    
        public class CustomTraceListener : TextWriterTraceListener
        {
            public CustomTraceListener(string file) : base(file){}    
            public override void WriteLine(string message)
            {
                base.Write(DateTime.Now.ToShortTimeString());
                base.Write("\t");
                base.WriteLine(message); // #1
                Writer.WriteLine(message); // #2
            }
        }
    }
