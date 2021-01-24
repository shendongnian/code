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
                XElement tx1 = doc.Descendants("Path").Where(x => (string)x.Attribute("Val") == "TX1").FirstOrDefault();
                List<XElement> losses = tx1.Elements("Loss").ToList();
                XElement loss1 = losses[1];
                loss1.SetValue("701.50,30.0");
            }
        }
    }
