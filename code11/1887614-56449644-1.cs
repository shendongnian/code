    public class CustomXmlTextWriter : XmlTextWriter
    {
        public CustomXmlTextWriter(TextWriter writer)
            : base(writer)
        {}
        public CustomXmlTextWriter(Stream stream, Encoding encoding)
            : base(stream, encoding)
        {}
        public CustomXmlTextWriter(string filename, Encoding encoding)
            : base(filename, encoding)
        {}
        public override void WriteEndElement()
        {
            this.WriteFullEndElement();
        } 
    }
