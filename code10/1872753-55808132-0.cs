    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    namespace ConsoleApplication110
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(INPUT_FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(XML));
                XML xml = (XML)serializer.Deserialize(reader);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(OUTPUT_FILENAME, settings);
                serializer.Serialize(writer, xml);
            }
        }
        public class XML
        {
            public int StatusCode { get; set; }
            public string Warnings { get; set; }
            [XmlArray("Errors")]
            [XmlArrayItem("Error")]
            public List<string> errors { get; set; }
        }
     
     
    }
