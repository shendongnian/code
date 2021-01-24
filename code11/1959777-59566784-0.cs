    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication143
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(INPUT_FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(Agent));
                Agent agent = (Agent)serializer.Deserialize(reader);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(OUTPUT_FILENAME, settings);
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("test","http://test.com");
                namespaces.Add("test2","http://test2.com");
                serializer.Serialize(writer, agent, namespaces);
     
     
            }
        }
        [XmlRoot(ElementName = "agent")]
        public class Agent
        {
            [XmlElement(ElementName = "name", Namespace = "http://test.com")]
            public Name name { get; set; }
            [XmlElement(ElementName = "interests", Namespace = "http://test.com")]
            public Interests interests { get; set; }
            [XmlElement(ElementName = "foo", Namespace = "http://test2.com")]
            public Foo foo { get; set; }
        }
        public class Name
        {
            [XmlAttribute("id")]
            public int id { get; set; }
        }
        public class Interests
        {
            [XmlElement(ElementName = "ddfsdf", Namespace = "http://test2.com")]
            public DDFSDF ddfsdf { get; set; }
            [XmlElement(ElementName = "interest", Namespace = "")]
            public List<Interest> interest { get; set; }
        }
        public class Interest
        {
            [XmlText]
            public string text { get; set; }
        }
        public class DDFSDF
        {
            [XmlText]
            public string text { get; set; }
        }
        public class Foo
        {
            [XmlText]
            public string text { get; set; }
        }  
    }
