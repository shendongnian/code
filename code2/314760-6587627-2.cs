    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var values = doc.XPathSelectElements("//Mapping[@name='abc']");
            foreach (var item in values)
            {
                foreach (var att in item.Elements("Attribute"))
                {
                    var name = att.Attribute("name").Value;
                    var value = att.Attribute("value").Value;
                    Console.WriteLine("{0}: {1}", name, value);
                }
            }
        }
    }
