    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string soap = File.ReadAllText(FILENAME);
                StringReader sReader = new StringReader(soap);
                XmlReader reader = XmlReader.Create(sReader);
                XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                Envelope envelope = (Envelope)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body body { get; set; }
        }
        public class Body
        {
            [XmlElement(ElementName = "CreateSessionResponse", Namespace = "http://some link")]
            public CreateSessionResponse CreateSessionResponse { get; set; }
        }
        public class CreateSessionResponse
        {
            [XmlElement(ElementName = "CreateSessionResult", Namespace = "http://some link")]
            public CreateSessionResult CreateSessionResult { get; set; }
        }
        public class CreateSessionResult
        {
            [XmlElement(ElementName = "output", Namespace = "http://some link")]
            public Output Output { get; set; }
        }
        public class Output
        {
            [XmlElement]
            public string sessionId { get; set; }
        }
    }
