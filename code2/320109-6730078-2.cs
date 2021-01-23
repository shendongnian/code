    public class BigInteger : IXmlSerializable
    {
        public int Value;
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            // You should really a create schema for this.
            // Hardcoded is fine.
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            Value = int.Parse(reader.ReadString());
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteValue(Value.ToString());
        }
    }
