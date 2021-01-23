    public class XmlStringWriter : StringWriter
    {
        public XmlStringWriter(StringBuilder builder)
            : base(builder)
        {
        }
        public override Encoding Encoding
        {
            get { return Encoding.UTF8; }
        }
    }
