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
                List<XElement> children = root.Elements().ToList();
                string[] items = root.Descendants("items").Select(x => (string)x).ToArray();
                for (int i = 0; i < children.Count; i++)
                {
                    if (i == 0)
                    {
                        children[i].Element("items").ReplaceWith(new XElement("items", string.Join(",", items)));
                    }
                    else
                    {
                        children[i].Remove();
                    }
                }
            }
        }
    }
