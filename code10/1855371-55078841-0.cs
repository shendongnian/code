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
                var results = doc.Descendants("TV-show").Select(x => new
                {
                    name = (string)x.Element("name"),
                    episodes = x.Descendants("episodes").Count()
                }).ToList();
     
            }
        }
    }
