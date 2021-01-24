    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.IO;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                StringReader reader = new StringReader(xml);
                XmlSerializer serializer = new XmlSerializer(typeof(Return));
                Return _return = (Return)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("return")]
        public class Return
        {
            [XmlElement("fields")]
            public List<string> fields { get; set; }
            [XmlElement("values")]
            public List<Value> values { get; set; }
        }
        [XmlRoot("value")]
        public class Value
        {
            [XmlElement("value")]
            public List<string> value { get; set; }
        }
    }
