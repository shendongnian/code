    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    using System.Xml.Schema;
    using System.IO;
    namespace ConsoleApplication131
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                Sensor se = new Sensor()
                {
                    Data = 5,
                    otherData = 10,
                    MoreData = 15
                };
                XmlSchemas schemas = new XmlSchemas();
                XmlSchemaExporter exporter = new XmlSchemaExporter(schemas);
                XmlTypeMapping mapping = new XmlReflectionImporter().ImportTypeMapping(typeof(Sensor));
                exporter.ExportTypeMapping(mapping);
                StringWriter schemaWriter = new StringWriter();
                foreach (XmlSchema schema in schemas)
                {
                    schema.Write(schemaWriter);
                }
                XDocument doc = XDocument.Parse(schemaWriter.ToString());
                XElement root = doc.Root;
                XNamespace xs = root.GetNamespaceOfPrefix("xs");
                foreach (XElement _class in doc.Descendants(xs + "complexType"))
                {
                    List<XElement> elements = _class.Descendants(xs + "element").ToList();
                    if (elements.Count > 0)
                    {
                        XElement complexType = new XElement(xs + "complexType");
                        _class.Add(complexType);
                        XElement sequence = new XElement(xs + "sequence");
                        complexType.Add(sequence);
                        foreach (var prop in se.GetType().GetProperties())
                        {
                            string name = prop.Name;
                            string value = prop.GetValue(se, null).ToString();
                            XElement element = elements.Where(x => (string)x.Attribute("name") == name).FirstOrDefault();
                            string strType = (string)element.Attribute("type");
                            XElement newElement = new XElement(xs + "simpleType", new object[] {
                            new XElement(xs + "restriction", new object[] {
                                new XAttribute("base", strType),
                                new XElement(xs + "enumeration", new XAttribute("value", value))
                            })
                        });
                            sequence.Add(newElement);
                        }
                    }
                }
                doc.Save(FILENAME);
     
            }
        }
        public sealed class Sensor
        {
            public int Data { get; set; }
            public int otherData { get; set; }
            public int MoreData { get; set; }
        }
     
    }
