    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Data;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XNamespace nsD = doc.Root.GetNamespaceOfPrefix("d");
                XElement cells = doc.Descendants(nsD + "Cells").FirstOrDefault();
                var results = cells.Elements(nsD + "element").Select(x => new
                {
                    key = (string)x.Element(nsD + "Key"),
                    value = (string)x.Element(nsD + "Value"),
                    valueType = (string)x.Element(nsD + "ValueType")
                }).ToList();
            }
        }
    }
