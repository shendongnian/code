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
                List<XElement> toDelete = doc.Descendants("layer")
                    .Where(XElement => ((int)XElement.Attribute("locked") == 0) && ((string)XElement.Attribute("class") == "SvgMarker"))
                    .ToList();
                toDelete.Remove();
                doc.Save(FILENAME);
            }
         }
    }
