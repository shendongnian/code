    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication158
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, List<List<KeyValuePair<string, string>>>> dict = doc.Root.Elements()
                    .GroupBy(x => x.Name.LocalName, y => y.Elements()
                        .Select(z => z.Attributes().Select(a => new KeyValuePair<string, string>(a.Name.LocalName, (string)a)).ToList()).ToList())
                        .ToDictionary(x => x.Key, y => y.FirstOrDefault());
     
            }
        }
    }
