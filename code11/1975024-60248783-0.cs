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
                XDocument doc = XDocument.Load(FILENAME);
                XElement image = doc.Descendants().Where(x => x.Name.LocalName == "Image").FirstOrDefault();
                XNamespace nsN = image.GetNamespaceOfPrefix("x");
                XAttribute name = image.Attribute(nsN + "Name");
                name.SetValue("newName");
            }
        }
    }
