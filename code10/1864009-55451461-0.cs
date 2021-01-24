    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication107
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> keyValueOfstringOutcomeTests = doc.Descendants().Where(x => x.Name.LocalName.StartsWith("KeyValueOfstringOutcomeTest")).ToList();
                foreach (XElement keyValueOfstringOutcomeTest in keyValueOfstringOutcomeTests)
                {
                    keyValueOfstringOutcomeTest.ReplaceWith(new XElement("KeyValueOfstringOutcomeTest", keyValueOfstringOutcomeTest.Elements()));
                }
            }
        }
    }
