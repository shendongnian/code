    public class DictionarySerializer : IXmlSerializable
    {
        const string NS = "http://www.develop.com/xml/serialization";
    
        public IDictionary dictionary;
    
        public DictionarySerializer() 
        {
            dictionary = new Hashtable();
        }
        public DictionarySerializer(IDictionary dictionary)
        {
            this.dictionary = dictionary;
        }
    
        public void WriteXml(XmlWriter w)
        {
            w.WriteStartElement("dictionary", NS);
            foreach (object key in dictionary.Keys)
            {
                object value = dictionary[key];
                w.WriteStartElement("item", NS);
                w.WriteElementString("key", NS, key.ToString());
                w.WriteElementString("value", NS, value.ToString());
                w.WriteEndElement();
            }
            w.WriteEndElement();
        }
    
        public void ReadXml(XmlReader r)
        {
            r.Read(); // move past container
            r.ReadStartElement("dictionary");
            while (r.NodeType != XmlNodeType.EndElement)
            {            
                r.ReadStartElement("item", NS);
                string key = r.ReadElementString("key", NS);
                string value = r.ReadElementString("value", NS);
                r.ReadEndElement();
                r.MoveToContent();
                dictionary.Add(key, value);
            }
        }
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return LoadSchema();
        }
    }
