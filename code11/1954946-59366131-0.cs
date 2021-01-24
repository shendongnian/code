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
                XmlSerializer serializer = new XmlSerializer(typeof(Message));
                Message message = (Message)serializer.Deserialize(reader);
            }
        }
        [XmlRoot("MESSAGE")]
        public class Message
        {
            [XmlElement("NAME")]
            public string name { get; set; }
            [XmlElement("BODY")]
            public Body body { get; set; }
        }
        public class Body
        {
            [XmlElement("EQPID")]
            public string eqpid { get; set; }
            [XmlArray("ECS")]
            [XmlArrayItem("EC")]
            public List<EC> ec { get; set; }
        }
        public class EC
        {
            public int ECID { get; set; }  
            public string ECNAME { get; set; }
            public string ECDEF { get; set; } 
            public int ECSLL { get; set; } 
            public int ECSUL { get; set; } 
            public int ECWLL { get; set; }
            public int ECWUL { get; set; } 
        }
    }
