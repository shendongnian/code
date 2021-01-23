    public class CustomXmlTextWriter : XmlTextWriter
    {
        public CustomXmlTextWriter(string filename)
            : base(filename, Encoding.UTF8)
        {
    
        }
    
        public override void WriteStartDocument()
        {
            WriteRaw("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
        }
    
        public override void WriteEndDocument()
        {
        }
    }
