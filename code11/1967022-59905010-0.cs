    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                RootClass root = new RootClass()
                {
                    ID = "23",
                    Properties = new List<Property>() {
                        new Property() { PropertyType = "Type1", Properties = new List<string>() { "A", "B", "C"} },
                        new Property() { PropertyType = "Type2", Properties = new List<string>() { "A", "B", "C"} }
                    }
                };
                XElement rootClass = new XElement("RootClass", new object[] {
                    new XElement("ID", root.ID),
                    new XElement("Properties")
                });
                XElement properties = rootClass.Element("Properties");
                int count = 1;
                foreach (Property property in root.Properties)
                {
                    XElement type = new XElement(property.PropertyType);
                    properties.Add(type);
                    foreach (string p in property.Properties)
                    {
                        XElement strProperty = new XElement("Property", new object[] {
                            new XElement(p, count++)
                        });
                        type.Add(strProperty);
                    }
                }
                rootClass.Save(FILENAME);
            }
        }
        public class RootClass
        {
            public string ID { get; set; }
            public List<Property> Properties { get; set; }
        }
        public class Property
        {
            public string PropertyType { get; set; }
            public List<string> Properties { get; set; }
        }
    }
