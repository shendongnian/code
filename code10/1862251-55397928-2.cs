    using System;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Linq;
    using System.Xml.Serialization;
    
    namespace MaPiTest
    {
        public class Utf8StringWriter : StringWriter
        {
            public sealed override Encoding Encoding { get { return Encoding.UTF8; } }
        }
    
        class Program
        {
            public static string SerializeAsUtf8<T>(XmlSerializer serializer, T o, XmlSerializerNamespaces ns)
            {
                using (var textWriter = new Utf8StringWriter())
                {
                    serializer.Serialize(textWriter, o, ns);
                    return textWriter.ToString();
                }
            }
    
            static void Main(string[] args)
            {
                ElementX elementX = new ElementX()
                {
                    ElementYNames = new ElementY[] {
                        new ElementY() {
                            FieldAmount =  new ElementYFieldAmountType() {
                                Amt = new FieldAmount() {
                                   Ccy = "VALUR",
                                   Value = 123.456M
                                }
                            },
                            Field1 = "a",
                            Field2 = "b",
                            Field3 = "c"
                        }
                    }
                };
    
                // Serialize
                XmlSerializer serializer = new XmlSerializer(typeof(ElementX));
                var namespaces = new XmlSerializerNamespaces();
                namespaces.Add("ac", "http://www.example.org/standards/xyz/1");
                namespaces.Add("rlc", "http://www.example.org/standards/def/1");
                namespaces.Add("def1", "http://www.lol.com/standards/lol.xsd");
                var xml = SerializeAsUtf8(serializer, elementX, namespaces);
    
                // Read into document.
                var doc = XDocument.Parse(xml);
                
                // Validate document with xsd.
                var schemas = new XmlSchemaSet();
                schemas.Add("", XmlReader.Create(new StringReader(File.ReadAllText("schema0.xsd"))));
                schemas.Add("http://www.example.org/standards/def/1", XmlReader.Create(new StringReader(File.ReadAllText("schema1.xsd"))));
    
                string error = null;
                doc.Validate(schemas, (o, e) => Console.WriteLine(error = e.Message));
    
            }
        }
    }
