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
=====
Edit: Harpreet asked for a complete code sample, so here it is below.
Note that I also added the closing `</soapenv:Envelope>` tag that was missing from his example XML.
c#
using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;
// REF:
// How to pass security token in header of a soap request
// https://stackoverflow.com/questions/57194919/how-to-pass-security-token-in-header-of-a-soap-request/57195772
namespace Parse_security_token_in_header_of_a_soap_request
{
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
    class Program
    {
        const string xml =
            "<soapenv:Envelope xmlns:ecm=\"http://www.ECMGenericWebService.ecm.aon.com/ECMGenericWS/\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\">\r\n" +
            "<soapenv:Header>\r\n" +
            "<wsse:Security xmlns:wsse=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-secext-1.0.xsd\" soapenv:mustUnderstand=\"1\">\r\n" +
            "<wsse:UsernameToken xmlns:wsu=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-wssecurity-utility-1.0.xsd\" wsu:Id=\"UsernameToken-8\">\r\n" +
            "<wsse:Username>rrrrr</wsse:Username>\r\n" +
            "<wsse:Password Type=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-username-token-profile-1.0#PasswordDigest\" >test</wsse:Password>\r\n" +
            "<wsse:Nonce EncodingType=\"http://docs.oasis-open.org/wss/2004/01/oasis-200401-wss-soap-message-security-1.0#Base64Binary\" >f8nUe3YupTU5ISdCy3X9Gg==</wsse:Nonce>\r\n" +
            "<wsu:Created>2011-05-04T19:01:40.981Z</wsu:Created>\r\n" +
            "</wsse:UsernameToken>\r\n" +
            "</wsse:Security>\r\n" +
            "</soapenv:Header>\r\n" +
            "</soapenv:Envelope>\r\n";
        static void Main(string[] args)
        {
            using (var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml)))
            {
                var serializer = new XmlSerializer(typeof(Envelope));
                var envelope = (Envelope)serializer.Deserialize(stream);
                // Do stuff with Envelope here...
                Console.WriteLine(envelope);
            }
        }
    }
}
