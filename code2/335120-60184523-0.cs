csharp
[XmlRoot(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
public partial class Security
{
    [XmlElement]
    public UsernameToken UsernameToken { get; set; }
}
[XmlRoot(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd")]
public class UsernameToken
{
    [XmlAttribute(Namespace = "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd")]
    public string Id { get; set; }
    [XmlElement]
    public string Username { get; set; }
    [XmlElement]
    public Password Password { get; set; }
    [XmlElement]
    public Nonce Nonce { get; set; }
}
public class Password
{
    [XmlAttribute]
    public string Type { get; set; }
    [XmlText]
    public string Value { get; set; }
}
public class Nonce
{
    [XmlAttribute]
    public string EncodingType { get; set; }
    [XmlText]
    public string Value { get; set; }
}
And then I was trying to deserialize this SOAP to those model ahead:
charp
var soapSecurityHeaderIndex = OperationContext.Current.IncomingMessageHeaders.FindHeader("Security", "http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd");
if(soapSecurityHeaderIndex != -1)
{
    var xmlReader = OperationContext.Current.IncomingMessageHeaders.GetReaderAtHeader(soapSecurityHeaderIndex);
    var serializer = new XmlSerializer(typeof(Security));
    var result = (Security)serializer.Deserialize(xmlReader);
    // do something with result
}
