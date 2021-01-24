    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    namespace ConsoleApplication120
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                List<string> drawingList = new List<string>() { "file1", "file2", "file3", "file4"};
                XDocument doc = new XDocument(
                    new XElement("Project",
                        new XElement("Name", "abc"),
                        new XElement("Path", @"c:\temp\"),
                         new XElement("Drawing")
                    )
               );
                XElement xDrawing = doc.Descendants("Drawing").FirstOrDefault();
                foreach (string drawing in drawingList)
                {
                    xDrawing.Add(new XElement("Drawing", drawing));
                }
            }
        }
    }
