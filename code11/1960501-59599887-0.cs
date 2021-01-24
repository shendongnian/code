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
                
                string responseString = File.ReadAllText(FILENAME);
                StringReader sReader = new StringReader(responseString);
                XmlReader reader = XmlReader.Create(sReader);
                XmlSerializer serializer = new XmlSerializer(typeof(TResponse));
                TResponse tResponse = (TResponse)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class TResponse
        {
            [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public ResponseBody Body { get; set; }
        }
        public class ResponseBody
        {
            [XmlElement(ElementName = "ManageTerminalResponse", Namespace = "http://tpress.com.tx/")]
            public ManagterminalResponse ManageTerminalResponse { get; set; }
        }
        public class ManagterminalResponse
        {
            [XmlElement(ElementName = "ManageTerminalResult", Namespace = "http://tpress.com.tx/")]
            public ManageTerminalRslt ManageTerminalResult { get; set; }
        }
        public class ManageTerminalRslt
        {
            [XmlElement(Namespace = "http://schemas.data.")]
            public string Checksum { get; set; }
            [XmlElement(Namespace = "http://schemas.data.")]
            public string Message { get; set; }
            [XmlElement(Namespace = "http://schemas.data.")]
            public string ResponseCode { get; set; }
            [XmlElement(Namespace = "http://schemas.data.")]
            public string WorkKey { get; set; }
        }
    }
