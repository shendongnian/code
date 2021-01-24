    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.IO;
    namespace ConsoleApplication108
    {
        class Program
        {
            const string FILENAME = @"c:\temp\test.xml";
            static void Main(string[] args)
            {
                XDocument doc = XDocument.Load(FILENAME);
                List<XElement> brs = doc.Descendants("br").ToList();
                for (int i = brs.Count - 1; i >= 0; i--)
                {
                    brs[i].ReplaceWith(new XElement("br", new XElement("p", new object[] {brs[i].Attributes(), brs[i].Nodes()})));
                }
     
     
            }
        }
     
      
    }
