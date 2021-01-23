    using System;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var values = doc.XPathSelectElements("//Attribute[@name='abc']");
            foreach (var item in values)
            {
                var name = item.Attribute("name").Value;
                var value = item.Attribute("value").Value;
                Console.WriteLine("{0}: {1}", name, value);
            }
        }
    }
