    public class CustomXmlTextReader : XmlTextReader
    {
        public CustomXmlTextReader(Stream stream) : base(stream) { }
    
        public override string ReadString()
        {
            return base.ReadString().Trim();
        }
    }
