    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication103
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                XElement body = doc.Descendants("body").FirstOrDefault();
                XElement results = body.Descendants("sec").Where(x => (string)x.Element("title") == "Third Title").FirstOrDefault();
                if (results != null)
                {
                    XElement newElement = XElement.Parse(results.ToString());
                    results.Remove();
                    body.AddFirst(newElement);
                }
     
            }
        }
    }
