    using System;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Program
    {
        static void Main()
        {
            var values = from field in XDocument.Load("test.xml")
                              .XPathSelectElements("//CP[@name='My Messages']/field")
                         where field.Attribute("name") != null
                         select field.Attribute("name").Value;
            Console.WriteLine("total values: {0}", values.Count());
            foreach (var value in values)
            {
                Console.WriteLine(value);
            }
        }
    }
