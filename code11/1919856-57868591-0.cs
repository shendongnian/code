    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication131
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Envelope));
                Envelope envelope = (Envelope)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "Envelope", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public class Envelope
        {
            [XmlElement(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
            public Header header { get; set; }
            [XmlElement(ElementName = "Body", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
            public Body body { get; set; }
        }
        [XmlRoot(ElementName = "Header", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
        public class Header
        {
            [XmlElement(ElementName = "Action", Namespace = "http://www.w3.org/2005/08/addressing")]
            public Action action { get; set; }
        }
        [XmlRoot(ElementName = "Action", Namespace = "http://www.w3.org/2005/08/addressing")]
        public class Action
        {
            [XmlAttribute(AttributeName = "mustUnderstand", Namespace = "http://www.w3.org/2003/05/soap-envelope")]
            public int mustUnderstand { get; set;}
            [XmlText]
            public string value { get;set;}
        }
        [XmlRoot(ElementName = "Body", Namespace = "")]
        public class Body
        {
            [XmlElement(ElementName = "BatchResponse", Namespace = "https://example.com/operations")]
            public BatchResponse batchResponse { get; set; }
        }
        [XmlRoot(ElementName = "BatchResponse", Namespace = "https://example.com/operations")]
        public class BatchResponse
        {
            [XmlElement(ElementName = "BatchResult", Namespace = "https://example.com/operations")]
            public BatchResult batchResult { get; set; }
        }
        [XmlRoot(ElementName = "BatchResult", Namespace = "https://example.com/operations")]
        public class BatchResult
        {
            [XmlElement(ElementName = "FailureMessages", Namespace = "https://example.com/responses")]
            public string failureMessages { get; set; }
            [XmlElement(ElementName = "FailureType", Namespace = "https://example.com/responses")]
            public string failureType { get; set; }
            [XmlElement(ElementName = "ProcessedSuccessfully", Namespace = "https://example.com/responses")]
            public Boolean  processedSuccessfully { get; set; }
            [XmlElement(ElementName = "SessionId", Namespace = "https://example.com/responses")]
            public string sessionId { get; set; }
            [XmlElement(ElementName = "TotalPages", Namespace = "https://example.com/responses")]
            public int totalPages { get; set; }
        }
    }
