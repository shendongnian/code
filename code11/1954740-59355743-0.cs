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
                //using a list
                Dictionary<string, List<XElement>> appData1 = doc.Root.Elements()
                    .GroupBy(x => x.Name.LocalName, y => y)
                    .ToDictionary(x => x.Key, y => y.ToList());
                //not using a list
                Dictionary<string, XElement> appData2 = doc.Root.Elements()
                    .GroupBy(x => x.Name.LocalName, y => y)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
         }
    }
