    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication131
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                XElement element = doc.Descendants().Where(x => x.Name.LocalName == "DocumentElement").FirstOrDefault();
                XElement newXml = (XElement)element.FirstNode; 
            }
        }
     
    }
