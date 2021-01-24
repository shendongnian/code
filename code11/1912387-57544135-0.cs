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
                List<XElement> contents = doc.Descendants("contents").ToList();
                for (int i = contents.Count - 1; i >= 0; i--)
                {
                    contents[i].Remove();
                }
            }
        }
    }
