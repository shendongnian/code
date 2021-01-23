    public class XmlFragmentWriter : XmlTextWriter
    {
        // Add whichever constructor(s) you need, e.g.:
        public XmlFragmentWriter(Stream stream, Encoding encoding) : base(stream, encoding)
        {
        }
    
        public override void WriteStartDocument()
        {
           // Do nothing (omit the declaration)
        }
    }
