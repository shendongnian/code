    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                string input = File.ReadAllText(FILENAME);
                XDocument doc = XDocument.Parse(input);
                string[] data = doc.Descendants("items").Select(x => (string)x).ToArray();
                string splitData = string.Join(" / ", data.Select((x, i) => new { data = x, index = i }).GroupBy(x => x.index / 2).Select(x => string.Join(" , ", x.Select(y => y.data))));
                XElement newDoc = new XElement("root", new XElement("table", new XElement("items", splitData)));
            }
        }
    }
