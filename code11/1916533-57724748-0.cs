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
            const string OLD_FILENAME = @"c:\temp\test.xml";
            const string NEW_FILENAME = @"c:\temp\test2.xml";
            static void Main(string[] args)
            {
                XDocument oldDoc = XDocument.Load(OLD_FILENAME);
                XDocument newDoc = XDocument.Load(NEW_FILENAME);
                var query = (from o in oldDoc.Descendants("resource")
                            join n in newDoc.Descendants("resource") on (string)o.Attribute("id") equals (string)n.Attribute("id")
                            select new { o = o, n = n })
                           .ToList();
                foreach (var item in query)
                {
                    item.n.Element("value").SetValue((string)item.o.Element("value"));
                }
            }
        }
      
    }
