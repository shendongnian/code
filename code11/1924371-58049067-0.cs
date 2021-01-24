    public class XmlSerializerOutputFormatterNamespace : XmlSerializerOutputFormatter
    {
        protected override void Serialize(XmlSerializer xmlSerializer, XmlWriter xmlWriter, object value)
        {
            var memoryStream = new MemoryStream();
            xmlSerializer.Serialize(memoryStream, value);
            memoryStream.Seek(0, SeekOrigin.Begin);
            //requires using System.Xml.Linq;
            XDocument document = XDocument.Load(memoryStream);
            document.Root.RemoveAttributes();
            document.WriteTo(xmlWriter);
        }
    }
