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
                foreach (XElement node in doc.Descendants("Node"))
                {
                    XElement songs = node.Descendants("songs").FirstOrDefault();
                    XCData child = (XCData)songs.FirstNode;
                    string childStr = child.ToString();
                    childStr = childStr.Replace("Some text here", "Some text there");
                    child.ReplaceWith(childStr);
                }
            }
        }
    }
