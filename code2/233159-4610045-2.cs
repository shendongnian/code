    public class MyType : IXmlSerializable
    {
        void IXmlSerializable.WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("xmlns:xsd", "http://www.w3.org/2001/XMLSchema");
            writer.WriteAttributeString("xsi", "noNamespaceSchemaLocation", XmlSchema.InstanceNamespace, "mySchema.xsd");
            // other elements & attributes
        }
        XmlSchema IXmlSerializable.GetSchema()
        {
            throw new NotImplementedException();
        }
        void IXmlSerializable.ReadXml(XmlReader reader)
        {
            throw new NotImplementedException();
        }
    }
    xmlSerializer.Serialize(xmlWriter, myTypeInstance);
