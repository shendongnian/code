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
            this.Hotels = from h in XDocument.Load(Reader)
                          select new Hotel
                          {
                              Name = (string)h.Attribute("name")
                          }
                          .ToList();
        }
        public void WriteXml(XmlWriter writer)
        {
            throw new NotSupportedException();
        }
    }
