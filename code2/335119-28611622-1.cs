    [DataContract(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd", Name = "Security")]
    public partial class SecurityHeaderType
    {
        [XmlElementAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        [DataMember]
        public UsernameToken UsernameToken { get; set; }
    }
    public class UsernameToken : IXmlSerializable
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Nonce { get; set; }
        public string Created { get; set; }
        public XmlSchema GetSchema()
        {
            throw new NotImplementedException();
        }
        public void ReadXml(XmlReader reader)
        {
            Dictionary<string, string> secDictionary;
            string xml = reader.ReadOuterXml();
            using (var s = GenerateStreamFromString(xml))
            {
                secDictionary =
                            XElement.Load(s).Elements()
                            .ToDictionary(e => e.Name.LocalName, e => e.Value);
            }
            Username = secDictionary["Username"];
            Password = secDictionary["Password"];
            Nonce = secDictionary["Nonce"];
            Created = secDictionary["Created"];          
        }
