    public class Mail : IXmlSerializable
    {
        public string Subject;
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(System.Xml.XmlReader reader)
        {
            bool isEmpty = reader.IsEmptyElement;
            reader.ReadStartElement();  
            if (isEmpty) return;
            isEmpty = reader.IsEmptyElement;
            reader.ReadStartElement();
            if (isEmpty)
            {
                reader.ReadEndElement();
                return;
            }
            Subject = reader.ReadString();
            
            reader.ReadEndElement();
            reader.ReadEndElement();
        }
        public void WriteXml(System.Xml.XmlWriter writer)
        {
            writer.WriteStartElement("MailSubject");
            writer.WriteElementString("Subject", Subject);
            writer.WriteEndElement();
        }
    }
