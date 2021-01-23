    public class SafeXmlSerializer : XmlSerializer
    {
        public SafeXmlSerializer(Type type) : base(type) { }
        public new void Serialize(StreamWriter stream, object o)
        {
            XmlWriterSettings ws = new XmlWriterSettings();
            ws.NewLineHandling = NewLineHandling.Entitize;
            using (XmlWriter xmlWriter = XmlWriter.Create(stream, ws))
            {
                base.Serialize(xmlWriter, o);
            }
        }
    }
