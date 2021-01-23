    using System;
    using System.IO;
    using System.Xml;
    
    class GetValue{
        public static void Main(){
            var xmlDoc = new XmlDocument();
            xmlDoc.Load("test.xml");
    
            var xmlRoot = xmlDoc.DocumentElement;
            var nsmgr = new XmlNamespaceManager(xmlDoc.NameTable);
            nsmgr.AddNamespace("content", "sitename.xsd");
            var attr = xmlRoot.SelectSingleNode("descendant::content:Source/@OrganizationName[../../../@Id='3212']", nsmgr);
            if(attr == null)
                Console.WriteLine("not found!");
            else
                Console.WriteLine(attr.Value);
        }
    }
