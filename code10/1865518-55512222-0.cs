    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication107
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement objectList = doc.Descendants("ObjectList").FirstOrDefault();
                XElement multilingualText = objectList.Element("MultilingualText");
                objectList.Add(XElement.Parse(multilingualText.ToString()));
     
            }
        }
     
     
    }
