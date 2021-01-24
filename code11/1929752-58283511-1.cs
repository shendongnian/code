    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication135
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                CertificateRequest request = new CertificateRequest();
                XmlSerializer serializer = new XmlSerializer(typeof(CertificateRequest));
                serializer.Serialize(writer, request);
            }
        }
        public class CertificateRequest
        {
            public string Name { get; set; }
            public string RequestNumber { get; set; }
            [XmlArray("TradeUnits")]
            [XmlArrayItem("TradeUnit")]
            public List<TradeUnit> tradeUnits { get; set; }
            public CertificateRequest()
            {
                Name = "Some Name";
                RequestNumber = "Req001";
                tradeUnits = new List<TradeUnit>() {
                    new TradeUnit() { TradeUnitNumber = "TUN0001"},
                    new TradeUnit() { TradeUnitNumber = "TUN0002"},
                    new TradeUnit() { TradeUnitNumber = "TUN0003"}
                };
            }
        }
        public class TradeUnit
        {
            public string TradeUnitNumber { get; set; }
        }
     
    }
