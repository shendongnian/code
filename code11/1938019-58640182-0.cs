    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication139
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
        [XmlRoot(Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public class Envelope
        {
            [XmlElement (Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
            public Body Body { get; set; }
        }
        public class Body
        {
            [XmlElement(Namespace = "http://webservices.talktalkplc.com/NetworkProductAvailabilityCheckerService")]
            public GetAvailabilityResponse GetAvailabilityResponse { get; set; }
        }
        public class GetAvailabilityResponse
        {
            [XmlElement(Namespace = "http://webservices.talktalkplc.com/NetworkProductAvailabilityCheckerService")]
            public GetAvailabilityResult GetAvailabilityResult { get; set; }
        }
        public class GetAvailabilityResult
        {
            [XmlArray("EADAvailability", Namespace = "http://webservices.talktalkplc.com/NetworkProductAvailabilityCheckerService")]
            [XmlArrayItem("AvailabilityDetails", Namespace = "http://webservices.talktalkplc.com/NetworkProductAvailabilityCheckerService")]
            public AvailabilityDetails[] AvailabilityDetails { get; set; }
        }
        [XmlInclude(typeof(EADAvailabilityDetails))]
        [Serializable, XmlRoot("AvailabilityDetails", Namespace = "http://webservices.talktalkplc.com/NetworkProductAvailabilityCheckerService")]
        public class AvailabilityDetails
        {
        }
        [Serializable, XmlRoot("EADAvailabilityDetails", Namespace = "http://webservices.talktalkplc.com/NetworkProductAvailabilityCheckerService")]
        public class EADAvailabilityDetails : AvailabilityDetails
        {
            [XmlArray("EADAvailability", Namespace = "http://webservices.talktalkplc.com/NetworkProductAvailabilityCheckerService")]
            [XmlArrayItem("EADAvailabilityResult", Namespace = "http://webservices.talktalkplc.com/NetworkProductAvailabilityCheckerService")]
            public EADAvailabilityResult[] EADAvailabilityResult { get; set; }
        }
        public class EADAvailabilityResult
        {
            public string CollectorNodeExchangeCode { get; set; }
            public string CollectorNodeExchangeName { get; set; }
            public int Distance { get; set; }
            public EADBandwidth EADBandwidth { get; set; }
            public string EADSubType { get; set; }
            public string FibreExchangeCode { get; set; }
            public string FibreExchangename { get; set; }
            public string IndicativeECC { get; set; }
            public string IndicativeOrderCategory { get; set; }
            public string LocalExchangeCode { get; set; }
            public string LocalExchangeName { get; set; }
            public int ORLeadTime { get; set; }
            public string OrderCategoryExplanation { get; set; }
            public int TTLeadTime { get; set; }
            public string Zone { get; set; }
        }
        public class EADBandwidth
        {
            [XmlElement(ElementName = "string", Type = typeof(string), Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays")]
            public string String { get; set; }
        }
     
     
    }
