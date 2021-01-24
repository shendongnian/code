    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication142
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Process));
                Process proc = (Process)serializer.Deserialize(reader);
            }
        }
        [Serializable]
        [XmlRootAttribute("Golden")]
        public class Process
        {
            [XmlElementAttribute("SecType")]
            public SecType secType { get; set; }
            [XmlElementAttribute("Request")]
            public Request request { get; set; }
        }
        [Serializable]
        [XmlRootAttribute("SecType")]
        public class SecType 
        {
            [XmlElementAttribute("ID")]
            public string ID { get; set; }
            [XmlElementAttribute("Count")]
            public int Count { get; set; }
        }
        [Serializable]
        [XmlRootAttribute("Request")]
        public class Request
        {
            [XmlElementAttribute("Action")]
            public string Action { get; set; }
            [XmlArray("Keys")]
            [XmlArrayItem("Key")]
            public Key[] keys { get; set; }
        }
        [Serializable]
        [XmlRootAttribute("Key")]
        public class Key
        {
            [XmlElementAttribute("ReferenceType")]
            public string ReferenceType { get; set; }
            [XmlElementAttribute("ReferenceValue")]
            public string ReferenceValue { get; set; }
            [XmlElementAttribute("Description")]
            public string Description { get; set; }
        }
     
    }
