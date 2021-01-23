    public class CustomXmlTextWriter : XmlTextWriter
    {
        public CustomXmlTextWriter(string filename)
            : base(filename, Encoding.UTF8)
        {
    
        }
    
        public override void WriteStartDocument()
        {
            WriteRaw("<?xml VERSION=\"1.0\" ENCODING=\"UTF-8\"?>");
        }
    
        public override void WriteEndDocument()
        {
        }
    }
