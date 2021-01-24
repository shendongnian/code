    [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Header Header { get; set; }
    }
    public class Header
    {
        [XmlElement(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public Security Security { get; set; }
    }
    public class Security
    {
        [XmlAttribute(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public int mustUnderstand { get; set; }
        [XmlElement(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
        public UsernameToken UsernameToken { get; set; }
    }
    public class UsernameToken
    {
        [XmlAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
        public string Id { get; set; }
        public string Username { get; set; }
        public Password Password { get; set; }
        public Nonce Nonce { get; set; }
        [XmlElement(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
        public DateTime Created { get; set; }
    }
    public class Password
    {
        [XmlAttribute()]
        public string Type { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
    public class Nonce
    {
        [XmlAttribute()]
        public string EncodingType { get; set; }
        [XmlText]
        public string Value { get; set; }
    }
At which point you can then deserialize it with an XmlSerializer instance, e.g.:
const string xml = "...";
using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
{
    var serializer = new XmlSerializer(typeof(Envelope));
    var envelope = (Envelope)serializer.Deserialize(stream);
    // Do stuff with Envelope, Security, UsernameToken, etc here...
}
