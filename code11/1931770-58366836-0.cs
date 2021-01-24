    public class CustomWriter : XmlTextWriter
    {
        public CustomWriter(TextWriter writer) : base(writer) { }
        public CustomWriter(Stream stream, Encoding encoding) : base(stream, encoding) { }
        public CustomWriter(string filename, Encoding encoding) : base(filename, encoding) { }
        public List<string> FieldList { get; set; }
        private string _localName;
        public override void WriteStartElement(string prefix, string localName, string ns)
        {
            if (!FieldList.Contains(localName))
                base.WriteStartElement(prefix, localName, ns);
            else
                _localName = localName;
        }
        public override void WriteString(string text)
        {
            if (!FieldList.Contains(_localName))
                base.WriteString(text);
        }
        public override void WriteEndElement()
        {
            if (!FieldList.Contains(_localName))
                base.WriteEndElement();
            else
                _localName = null;
        }
    }
