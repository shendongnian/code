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
                XElement root = doc.Root;
                XNamespace ns = root.GetDefaultNamespace();
                List<XElement> values1s = doc.Descendants(ns + "value").Where(x => (string)x == "11111111111111111111111111111111").ToList();
                foreach (XElement x in values1s)
                {
                    x.SetValue(((string)x).Replace("1", "A"));
                }
            }
        }
    }
