    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication132
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string xml = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(xml);
                List<XElement> AKONTAS = doc.Descendants("AKONTAS").ToList();
                var results = AKONTAS.Select(x => x.Elements().Select(y => new KeyValuePair<string, string>(y.Name.LocalName, (string)y)).ToList()).ToList();
                foreach (var result in results)
                {
                    Console.WriteLine(string.Join(",", result.Select(x => x.Key + " : " + x.Value)));
                }
                Console.ReadLine();
            }
        }
    }
