    using System;
    using System.Xml.Linq;
    
    class Test
    {
        static void Main()
        {
            XNamespace ns = "http://www.acme.com/ABC";
            DateTimeOffset date = new DateTimeOffset(2011, 9, 16, 10, 43, 54, 91,
                                                     TimeSpan.FromHours(1));
            XDocument doc = new XDocument(
                new XElement(ns + "ABC",
                             new XAttribute("xmlns", ns.NamespaceName),
                             new XAttribute(XNamespace.Xmlns + "xsi",
                                  "http://www.w3.org/2001/XMLSchema-instance"),
                             new XAttribute("fileName", "acmeth.xml"),
                             new XAttribute("date", date),
                             new XAttribute("origin", "TEST"),
                             new XAttribute("ref", "XX_88888")));
            
            Console.WriteLine(doc); 
        }
    }
