    [XmlRoot("customHeader", Namespace = "http://somecompany.com/webservices/security/2012/topSecret")]
    public class customHeader: SoapHeader, IXmlSerializable
    {
        public customHeader()
        {
            Actor = "http://schemas.xmlsoap.org/soap/actor/next";
            MustUnderstand = false;
        }
    
        public System.Xml.Schema.XmlSchema GetSchema()
        {
            return null;
            //throw new NotImplementedException();
        }
    
        public void ReadXml(XmlReader reader)
        {
            //throw new NotImplementedException();
        }
    
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("soap:actor", Actor);
            writer.WriteAttributeString("soap:mustUnderstand", MustUnderstand ? "1" : "0");
            writer.WriteRaw("some encrypted data");
            //get it exactly the way you want it in here without mucking with Xml* property attributes for hours on end
            //writer.WriteElement(...);
        }
    }
