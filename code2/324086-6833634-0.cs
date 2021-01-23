    public class XmlFragmentWriter : XmlTextWriter
    {
        // Add whichever constructors are needed
        public XmlFragmentWriter(Stream stream, Encoding encoding) : base(stream, encoding)
        {
        }
    
        public override void WriteStartDocument()
        {
           // Do nothing (omit the declaration)
        }
    }
