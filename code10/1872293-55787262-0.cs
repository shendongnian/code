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
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XmlReaderSettings rSettings = new XmlReaderSettings();
                rSettings.Schemas = null;
                XmlReader reader = XmlReader.Create(INPUT_FILENAME, rSettings);
                XmlSerializer serializer = new XmlSerializer(typeof(Ref1), string.Empty);
                
                Ref1 ref1 = (Ref1)serializer.Deserialize(reader );
                
                XmlWriterSettings wSettings = new XmlWriterSettings();
                wSettings.Indent = true;
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add("","");
                XmlWriter writer = XmlWriter.Create(OUTPUT_FILENAME, wSettings);
                serializer.Serialize(writer, ref1, namespaces);
            }
        }
        public class Ref1
        {
            [XmlAttribute("Att11")]
            public string Att11 { get; set; }
            [XmlAttribute("Att21")]
            public string Att21 { get; set; }
            [XmlAttribute("Att31")]
            public string Att31 { get; set; }
            [XmlElement("Ref2")]
            public List<Ref2> ref2;
        }
        public class Ref2
        {
            [XmlAttribute("Att12")]
            public string Att12 { get; set; }
            [XmlAttribute("Att22")]
            public string Att22 { get; set; }
            [XmlAttribute("Att32")]
            public string Att32 { get; set; }
            [XmlElement("Ref3")]
            public Ref3 ref3;
        }
        public class Ref3
        {
            [XmlAttribute("Att13")]
            public string Att13 { get; set; }
            [XmlAttribute("Att23")]
            public string Att23 { get; set; }
            [XmlAttribute("Att33")]
            public string Att33 { get; set; }
        }
    }
