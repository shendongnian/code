    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleAppliation157
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                Dictionary<string, List<List<string>>> dict = doc.Root.Elements()
                    .GroupBy(x => x.Name.LocalName.ToUpper(), y => y.Elements().SelectMany(a => 
                        a.Elements().Select(b => new List<string> { a.Name.LocalName, b.Name.LocalName, (string)b })).ToList()).ToList()
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
