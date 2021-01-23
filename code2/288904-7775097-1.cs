    public class BoolYN : IXmlSerializable
    {
        public bool Value { get; set }
    
        #region IXmlSerializable members
    
        public System.Xml.Schema.XmlSchema GetSchema() {
            return null;
        }
    
        public void ReadXml(System.Xml.XmlReader reader) {
            string str = reader.ReadString();
            reader.ReadEndElement();
    
            switch (str) {
                case "Y":
                    this.Value = true;
                    break;
                case "N":
                    this.Value = false;
                    break;
            }
        }
    
        public void WriteXml(System.Xml.XmlWriter writer) {
            string str = this.Value ? "Y" : "N";
    
            writer.WriteString(str);
            writer.WriteEndElement();
        }
    
        #endregion
    }
