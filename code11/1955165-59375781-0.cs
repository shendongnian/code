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
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                DataPacket dataPacket = new DataPacket()
                {
                    metadata = new MetaData()
                    {
                        fields = new List<Field>() {
                            new Field() { width = 8, fieldtype = "string", attrname = "ID"},
                            new Field() { width = 30, fieldtype = "string", attrname = "NAME"}
                        }
                    },
                    rows = new List<Row>() {
                        new Row() { id = "00000000", name = "Peter"},
                        new Row() { id = "00000010", name = "Lucie"}
                    }
                };
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create(FILENAME, settings);
                XmlSerializer serializer = new XmlSerializer(typeof(DataPacket));
                serializer.Serialize(writer, dataPacket);
                        
                 
            }
        }
        [XmlRoot("DATAPACKET")]
        public class DataPacket
        {
            [XmlAttribute("Version")]
            public string version { get; set; }
            [XmlElement("METADATA")]
            public MetaData metadata { get; set;}
            [XmlArray("ROWDATA")]
            [XmlArrayItem("ROW")]
            public List<Row> rows { get; set; }
        }
        [XmlRoot("METADATA")]
        public class MetaData
        {
            [XmlArray("FIELDS")]
            [XmlArrayItem("FIELD")]
            public List<Field> fields { get; set; }
        }
        [XmlRoot("FIELD")]
        public class Field
        {
            [XmlAttribute("WIDTH")]
            public int width { get; set; }
            [XmlAttribute("fieldtype")]
            public string fieldtype { get; set; }
            [XmlAttribute("Version")]
            public string attrname { get; set; }
        }
        [XmlRoot("ROW")]
        public class Row
        {
            [XmlAttribute("ID")]
            public string  id { get; set; }
            [XmlAttribute("NAME")]
            public string name { get; set; }
        }
    }
