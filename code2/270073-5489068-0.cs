    using System;
    using System.Xml;
    using System.Xml.XPath;
    
    class Test
    {
        static void Main() 
        {
            string xmlFile = "test.xml";
            XPathDocument xmldoc = new XPathDocument(xmlFile); 
            XPathNavigator nav = xmldoc.CreateNavigator(); 
            XmlNamespaceManager nsMgr = new XmlNamespaceManager(nav.NameTable);
            nsMgr.AddNamespace("x", "http://www.rixml.org/2005/3/RIXML"); 
            XPathNavigator result = nav.SelectSingleNode("/x:Research", nsMgr);
            Console.WriteLine(result);
        }
    }
