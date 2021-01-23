    namespace MyNamespace
    {
        public class FormattedTextTracer : TextWriterTraceListener
        {
            public override void Close()
            {
                 // Write footer
                 Writer.WriteLine("==== Footer ====");
                 Writer.Flush();
                 base.Close();
            }
        }
    }
