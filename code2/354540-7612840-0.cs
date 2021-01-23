    using System;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.XPath;
    
    class Test
    {
        static void Main()
        {
            var doc = XDocument.Load("test.xml");
            var manager = new XmlNamespaceManager(new NameTable());
            manager.AddNamespace("foo", "TemplateXXX");
            
            var query = doc.XPathSelectElement("/foo:Report/foo:HEADER", manager);
            Console.WriteLine(query);
        }
    }
