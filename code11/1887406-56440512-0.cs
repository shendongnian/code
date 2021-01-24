    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication7
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> people = doc.Descendants("Person").ToList();
                foreach (XElement person in people)
                {
                    var children = person.Nodes().ToList();
                    person.ReplaceWith(new XElement("Person", new object[] {
                        new XElement("PersonDetailsList", children)
                    }));
                }
            }
        }
    }
