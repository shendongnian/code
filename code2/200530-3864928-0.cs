    public class ClassB : IXmlSerializable
    {
        private string _value;
        public string Value {
            get { return _value; }
            set { _value = value; }
        }
        public override string ToString()
        {
            return _value;
        }
        #region IXmlSerializable Members
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            _value = reader.ReadString();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteString(_value);
        }
        #endregion
    }
