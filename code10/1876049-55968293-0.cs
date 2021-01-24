    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using System.Xml.Linq;
    using System.Xml.Schema;
    namespace ConsoleApplication111
    {
        class Program
        {
            const string INPUT_FILENAME = @"c:\temp\test.xml";
            const string OUTPUT_FILENAME = @"c:\temp\test1.xml";
            static void Main(string[] args)
            {
                XmlReader reader = XmlReader.Create(INPUT_FILENAME);
                XmlSerializer serializer = new XmlSerializer(typeof(ElementType));
                ElementType elementType = (ElementType)serializer.Deserialize(reader);
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                XmlWriter writer = XmlWriter.Create (OUTPUT_FILENAME, settings);
                serializer.Serialize(writer, elementType);
            }
        }
        [XmlRoot("Element")]
        public partial class ElementType : IXmlSerializable
        {
            private string[] nameField;
            private string[] numberField;
            private string[] detailsField;
            /// <remarks/>
            [XmlElement(ElementName = "name", DataType = "token")]
            public string[] name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }
            /// <remarks/>
            [XmlElement(ElementName = "number", DataType = "token")]
            public string[] number
            {
                get
                {
                    return this.numberField;
                }
                set
                {
                    this.numberField = value;
                }
            }
            /// <remarks/>
            [XmlElement(ElementName = "details", DataType = "token")]
            public string[] details
            {
                get
                {
                    return this.detailsField;
                }
                set
                {
                    this.detailsField = value;
                }
            }
            public void ReadXml(XmlReader reader)
            {
                XElement elementType = XElement.Load(reader);
                nameField = elementType.Elements("name").Select(x => (string)x).ToArray();
                numberField = elementType.Elements("number").Select(x => (string)x).ToArray();
                detailsField = elementType.Elements("details").Select(x => (string)x).ToArray();
                
            }
            public void WriteXml(XmlWriter writer)
            {
                int count = nameField.Count();
                XElement element = new XElement("Element");
                for(int i = 0; i < count; i++)
                {
                    element.Add(new XElement("name", name[i]));
                    element.Add(new XElement("number", number[i]));
                    element.Add(new XElement("details", detailsField[i]));
                }
                writer.WriteRaw(element.ToString());
            }
            public XmlSchema GetSchema()
            {
                return (null);
            }
        }
    }
