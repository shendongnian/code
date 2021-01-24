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
                Dictionary<Type, Dictionary<Type, List<KeyValuePair<string, string>>>> dict = doc.Descendants("Transform")
                    .GroupBy(x => Type.GetType((string)x.Attribute("Input")), y => y)
                    .ToDictionary(x => x.Key, y => y.GroupBy(a => Type.GetType((string)a.Attribute("Output")), b => b.Elements("Map").Select(c => new KeyValuePair<string, string>((string)c.Attribute("Input"), (string)c.Attribute("Output"))).ToList())
                        .ToDictionary(a => a.Key, b => b.FirstOrDefault()));
            }
        }
    }
