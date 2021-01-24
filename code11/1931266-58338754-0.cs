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
                List<Component> components = doc.Descendants("Part").Select(x => new Component()
                {
                    ComponentNr = (string)x.Attribute("No"),
                    Omschrijving = (string)x.Elements().Where(y => y.Attribute("PartsName") != null).Select(y => (string)y.Attribute("PartsName")).FirstOrDefault(),
                    Pos = (int)x.Descendants().Where(y => y.Attribute("SetNo") != null).Select(y => (int)y.Attribute("SetNo")).FirstOrDefault()
                }).ToList();
                Dictionary<string, Component> dict = components
                    .GroupBy(x => x.ComponentNr, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
     
            }
        }
       public class Component
        {
            public string ComponentNr { get; set; }
            public string Omschrijving { get; set; }
            public int Aantal { get; set; }
            public int Pos { get; set; }
        }
    }
