    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication1
    {
        public class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string response = File.ReadAllText(FILENAME);
                StringReader sReader = new StringReader(response);
                XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                Envelope envelope = (Envelope)serializer.Deserialize(sReader);
     
            }
        }
        [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body body { get;set;}
        }
        [XmlRoot(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Body
        {
            [XmlElement(ElementName = "MyAction", Namespace = "http://mycompanyname.co.uk")]
            public MyAction myAction { get; set; }
        }
        [XmlRoot(ElementName = "MyAction", Namespace = "http://mycompanyname.co.uk")]
        public class MyAction
        {
            [XmlElement(ElementName = "someObject", Namespace = "")]
            public SomeObject someObject { get; set; }
        }
        [XmlRoot(ElementName = "someObject", Namespace = "")]
        public class SomeObject
        {
            public string SomeField { get; set; }
        }
    }
