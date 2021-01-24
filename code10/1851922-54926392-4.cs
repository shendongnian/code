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
                List<XElement> results = body.Descendants("sec").Where(x => (string)x.Element("title") == "First Title").ToList();
                if (results != null)
                {
                    List<XElement> breaks = results.SelectMany(x => x.Elements("break")).ToList();
                    XElement newElement = XElement.Parse(results.FirstOrDefault().ToString());
                    newElement.Elements("break").Remove();
                    results.Remove();
                    newElement.Add(breaks);
                    body.AddFirst(newElement);
                }
            }
        }
    }
