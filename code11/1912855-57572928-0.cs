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
                XmlSerializer serializer = new XmlSerializer(typeof(GroupCreateUpdateResult));
                GroupCreateUpdateResult group = (GroupCreateUpdateResult)serializer.Deserialize(reader);
            }
        }
        [XmlRootAttribute(Namespace = "http://com.f24.soap.fwi.schema", IsNullable = false, ElementName = "OperationResult")]
        public class GroupCreateUpdateResult
        {
            [XmlElement(ElementName = "done", Namespace = "")]
            public string done { get; set; }
            [XmlElement(ElementName = "errorEntities", Namespace = "")]
            public ErrorEntities errorEntities { get; set; }
            //public bool hasErrors => done == "true" ? true : false;
        }
        [XmlRoot(ElementName = "errorEntities")]
        public class ErrorEntities
        {
            [XmlElement(ElementName = "elements", Namespace = "")]
            public List<ErrorElements> elements { get; set;}
        }
        [XmlRoot(ElementName = "elements")]
        public class ErrorElements
        {
            [XmlElement(ElementName = "entityID")]
            public string entityId { get; set; }
            [XmlElement(ElementName = "entityType")]
            public string entityType { get; set; }
            [XmlElement(ElementName = "errors", Namespace = "")]
            public Errors errors { get; set; }
        }
        [XmlRoot(ElementName = "errors")]
        public class Errors
        {
            [XmlElement(ElementName = "errorCode")]
            public string errorCode { get; set; }
            [XmlElement(ElementName = "errorMessage")]
            public string errorMessage { get; set; }
        }
    }
