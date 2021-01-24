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
            const string TABLE_NAME = "MJESTO";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement schema = doc.Descendants().Where(x => x.Name.LocalName == "schema").FirstOrDefault();
                XNamespace xs = schema.GetNamespaceOfPrefix("xs");
                XElement sequence = doc.Descendants(xs + "sequence").FirstOrDefault();
                string[] columnNames = sequence.Elements(xs + "element").Select(x => (string)x.Attribute("name")).ToArray();
                string query = string.Format("Select {0} FROM {1}", string.Join(",", columnNames), TABLE_NAME);
            }
        }
    }
