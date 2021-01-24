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
                var results = doc.Descendants("shelf").SelectMany(x => x.Descendants("location").Select(y => (x.FirstNode.ToString()).Trim() + " " + (string)y)).ToList();
            }
        }
    }
