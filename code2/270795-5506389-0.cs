    using System;
    using System.Xml;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                DeleteNode("Něco");
            }
    
            public static void DeleteNode(string title)
            {
                XmlDocument doc = LoadXmlDoc();
                XmlElement node = FindNodeByTitle(doc, title);
                node.ParentNode.RemoveChild(node);
                SaveXmlDoc(doc);
            }
    
            private static XmlDocument LoadXmlDoc()
            {
                XmlDocument doc = new XmlDocument();
                doc.Load("C:\\test.xml");
                return doc;
            }
    
            private static void SaveXmlDoc(XmlDocument doc)
            {
                string AbsPath = "C:\\test.xml";
                doc.Save(AbsPath);
            }
    
            private static XmlElement FindNodeByTitle(XmlDocument doc, string title)
            {
                string xPath = String.Format("//*[@title='{0}']", title);
                XmlElement node = doc.SelectSingleNode(xPath) as XmlElement;
                if(node == null)
                    throw new Exception("Node not found with title: " + title);
                return node;
            }
        }
    }
