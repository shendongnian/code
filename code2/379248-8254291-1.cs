    <Hotels>
        <Hotel />
        <Hotel />
    </Hotels>
---
    [XmlRoot("Hotels")]
    public class HotelList : IXmlSerializable
    {
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
        }
        public void ReadXml(XmlReader reader)
        {
            this.Hotels = XDocument.Load(reader)
                                   .Select(h => new Hotel { Name = (string)h.Attribute("name") }
                                   .ToList();
        }
        public void WriteXml(XmlWriter writer)
        {
            throw new NotSupportedException();
        }
    }
