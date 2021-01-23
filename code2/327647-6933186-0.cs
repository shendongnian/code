    public class XmlSerializableEntity : IXmlSerializable
    {
        public XmlSchema GetSchema()
        {
            // Implementation omitted for clarity
        }
    
        public void ReadXml(XmlReader reader)
        {
            // Implementation omitted for clarity
        }
    
        public void WriteXml(XmlWriter writer)
        {
            // Other parts of the serialization process are omitted for clarity
        
            var properties = from property in this.GetType().GetProperties()
                             where property.PropertyType.IsPrimitive
                             select property;
    
            foreach (var property in properties)
            {
                var name = property.Name;
                var value = property.GetValue(this, null).ToString();
                writer.WriteAttributeString(name, value);
            }
        }
    }
