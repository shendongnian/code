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
                XmlSerializer serializer = new XmlSerializer(typeof(Foos));
                Foos foos = (Foos)serializer.Deserialize(reader);
            }
        }
        [XmlRoot(ElementName = "foos")]
        public class Foos
        {
            [XmlElement("foo")]
            public List<Foo> foo { get; set; }  
        }
        [XmlRoot("foo")]
        public class Foo
        {
            [XmlElement("bar")]
            public Bar bar { get; set; }
        }
        [XmlRoot("bar")]
        public class Bar
        {
            [XmlArray("bazs")]
            [XmlArrayItem("baz")]
            public List<string> baz { get; set; }
        }
     
    }
