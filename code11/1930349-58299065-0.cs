    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Request));
                Request request = (Request)serializer.Deserialize(reader);
            }
        }
        public class Request
        {
            [XmlAttribute]
            public string deploymentMode { get; set; }
            public ConfirmationRequest ConfirmationRequest { get; set; } 
        }
        public class ConfirmationRequest
        {
            public ConfirmationHeader ConfirmationHeader { get; set; }
            public OrderReference OrderReference { get; set; }
            [XmlElement]
            public List<ConfirmationItem> ConfirmationItem { get; set; }
        }
        public class ConfirmationHeader
        {
            private DateTime _noticeDate { get; set; }
            [XmlAttribute]
            public string noticeDate {
                get { return _noticeDate.ToString(); }
                set { _noticeDate = DateTime.Parse(value); } 
            }
            [XmlAttribute]
            public string type { get; set; }
            [XmlAttribute]
            public string opertion { get; set; }
            [XmlAttribute]
            public string confirmID { get; set; }
        }
        public class OrderReference
        {
            [XmlAttribute]
            public string orderID { get; set; }
            public string value { get; set; }
        }
        public class ConfirmationItem
        {
            [XmlAttribute]
            public string lineNumber { get; set; }
            [XmlAttribute]
            public decimal quantity { get; set; }
            public string UnitOfMeasure { get; set; }
            public ConfirmationStatus ConfirmationStatus { get; set; } 
        }
        public class ConfirmationStatus
        {
            [XmlAttribute]
            public string type { get; set; }
            [XmlAttribute]
            public decimal quantity { get; set; }
            public string UnitOfMeasure { get; set; }
            [XmlElement]
            public string[] Comments { get; set; }
        }
    }
        
